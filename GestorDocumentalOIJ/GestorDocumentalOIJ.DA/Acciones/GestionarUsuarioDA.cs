﻿using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", usuario.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC SC.PA_ActualizarUsuario @pN_Id, @pC_Nombre, @pC_Apellido, @pC_Correo, @pC_Password, @pN_RolID, @pB_Activo, @pB_Eliminado",
                                              idParameter,
                                              nombreParameter,
                                              apellidoParameter,
                                              correoParameter,
                                              passwordParameter,
                                              rolParameter,
                                              activoParameter,
                                              eliminadoParameter);

            return resultado > 0;
        }

        public async Task<bool> Autenticar(string correo, string password)
        {
            var correoParameter = new SqlParameter("@pC_Correo", correo);
            var passwordParameter = new SqlParameter("@pC_Password", password);

            var resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC SC.PA_ValidarLoginUsuario @pC_Correo, @pC_Password",
                                              correoParameter,
                                              passwordParameter);

            return resultado > 0;
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
                                              "EXEC SC.PA_InsertarUsuario @pC_Nombre, @pC_Apellido, @pC_Correo, @pC_Password, @pN_RolID, @pB_Activo",
                                                      nombreParameter,
                                                      apellidoParameter,
                                                      correoParameter,
                                                      passwordParameter,
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
    }
}
