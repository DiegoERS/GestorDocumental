using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarUsuarioDA : IGestionarUsuarioDA
    {
        private readonly GestorDocumentalContext _context;


        public GestionarUsuarioDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            var idParameter = new SqlParameter("@pN_Id", usuario.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", usuario.Nombre);
            var apellidoParameter = new SqlParameter("@pC_Apellido", usuario.Apellido);
            var correoParameter = new SqlParameter("@pC_Correo", usuario.Correo);
            var passwordParameter = new SqlParameter("@pC_Password", usuario.Password);
            var rolParameter = new SqlParameter("@pN_RolID", usuario.RolID);
            var activoParameter = new SqlParameter("@pB_Activo", usuario.Activo);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC SC.PA_ActualizarUsuario @pN_Id, @pC_Correo, @pC_Nombre, @pC_Password, @pC_Apellido, @pN_RolID, @pB_Activo",
                                              idParameter,
                                              correoParameter,
                                              nombreParameter,
                                              passwordParameter,
                                              apellidoParameter,
                                              rolParameter,
                                              activoParameter);

            return resultado > 0;
        }

        public async Task<Usuario> Autenticar(string correo, string password)  // cambiar a un sp normal para controlar devoluciones
        {
            try
            {
                // Obtener la conexión de Entity Framework
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync();

                    // Crear el comando SQL para ejecutar el procedimiento almacenado
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SC.PA_ValidarLoginUsuario";
                        command.CommandType = CommandType.StoredProcedure;

                        // Añadir parámetros
                        var correoParameter = new SqlParameter("@pC_Correo", SqlDbType.NVarChar, 255) { Value = correo };
                        var passwordParameter = new SqlParameter("@pC_Password", SqlDbType.NVarChar, 255) { Value = password };
                        command.Parameters.Add(correoParameter);
                        command.Parameters.Add(passwordParameter);

                        // Ejecutar el procedimiento y leer los resultados
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Mapear los datos si se encontró un usuario
                                var usuario = new Usuario
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                                    Correo = reader.GetString(reader.GetOrdinal("Correo")),
                                    Password = reader.GetString(reader.GetOrdinal("Password")),
                                    RolID = reader.GetInt32(reader.GetOrdinal("RolID")),
                                    Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),
                                    Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                                };
                                return usuario;
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                // Manejar cualquier excepción de SQL
                return null;
            }

            // Retornar null si no se encontró usuario o en caso de error
            return null;
        }

        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", usuario.Nombre);
            var apellidoParameter = new SqlParameter("@pC_Apellido", usuario.Apellido);
            var correoParameter = new SqlParameter("@pC_Correo", usuario.Correo);
            var passwordParameter = new SqlParameter("@pC_Password", usuario.Password);
            var rolParameter = new SqlParameter("@pN_RolID", usuario.RolID);
            var activoParameter = new SqlParameter("@pB_Activo", usuario.Activo);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC SC.PA_InsertarUsuario @pC_Correo, @pC_Nombre, @pC_Password, @pC_Apellido, @pN_RolID, @pB_Activo",
                                                      correoParameter,
                                                      nombreParameter,
                                                      passwordParameter,
                                                      apellidoParameter,
                                                      rolParameter,
                                                      activoParameter);

            return resultado > 0;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC SC.PA_EliminarUsuario @pN_Id", new SqlParameter("@pN_Id", id)
                                                                                                                                                                                                                                                                               );

            return resultado > 0;
        }


        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var usuarios = await _context.Usuarios
                    .FromSqlRaw("EXEC SC.PA_ListarUsuarioPorId @pN_Id", idParametro)
                    .ToListAsync();

                var usuarioDA = usuarios.FirstOrDefault();

                if (usuarioDA != null)
                {
                    return new Usuario()
                    {
                        Id = usuarioDA.Id,
                        Nombre = usuarioDA.Nombre,
                        Apellido = usuarioDA.Apellido,
                        Correo = usuarioDA.Correo,
                        Password = usuarioDA.Password,
                        RolID = usuarioDA.RolID,
                        Activo = usuarioDA.Activo,
                        Eliminado = usuarioDA.Eliminado
                    };

                }
                return new Usuario();
            }
            catch (SqlException)
            {
                return new Usuario();
            }
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            var usuarios = await _context.Usuarios
                .FromSqlRaw("EXEC SC.PA_ListarUsuarios")
                .ToListAsync();
            return usuarios.Select(u => new Usuario
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Password = u.Password,
                RolID = u.RolID,
                Activo = u.Activo,
                Eliminado = u.Eliminado
            }).ToList();
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosPorOficinaID(int oficinaID)
        {
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", oficinaID);

            var usuarios = await _context.Usuarios
                .FromSqlRaw("EXEC SC.PA_ListarUsuariosPorOficina @pN_OficinaID", oficinaIDParameter)
                .ToListAsync();

            return usuarios.Select(u => new Usuario
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Password = u.Password,
                RolID = u.RolID,
                Activo = u.Activo,
                Eliminado = u.Eliminado
            }).ToList();
        }
    }
}
