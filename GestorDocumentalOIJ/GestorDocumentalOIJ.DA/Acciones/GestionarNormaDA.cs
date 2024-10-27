using GestorDocumentalOIJ.BC.Modelos;
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
    public class GestionarNormaDA:IGestionarNormaDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarNormaDA(GestorDocumentalContext context)
        {
            _context = context;
        }


        public async Task<bool> ActualizarNorma(Norma norma)
        {
            var idParameter = new SqlParameter("@pN_Id", norma.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", norma.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", norma.Descripcion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", norma.Eliminado);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", norma.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", norma.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC GD.PA_ActualizarNorma @pN_Id, @pC_Nombre, @pC_Descripcion, @pB_Eliminado, @pN_UsuarioID, @pN_OficinaID",
                                              idParameter,
                                              nombreParameter,
                                              descripcionParameter,
                                              eliminadoParameter,
                                              usuarioIDParameter,
                                              oficinaIDParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }

        public async Task<bool> CrearNorma(Norma norma)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", norma.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", norma.Descripcion);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", norma.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", norma.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC  GD.PA_InsertarNorma @pC_Nombre, @pC_Descripcion, @pN_UsuarioID, @pN_OficinaID",
                                              nombreParameter,
                                              descripcionParameter,
                                              usuarioIDParameter,
                                              oficinaIDParameter);

            return resultado > 0;

        }


        public async Task<bool> EliminarNorma(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                          "EXEC GD.PA_EliminarNorma @pN_Id", new SqlParameter("@pN_Id", id));

            return resultado > 0;

        }


        public async Task<IEnumerable<Norma>> ListarNormas()
        {
            var normas = await _context.Normas
         .FromSqlRaw("EXEC GD.PA_ListarNormas")
         .ToListAsync();
            return normas.Select(n => new Norma
            {
                Id = n.Id,
                Nombre = n.Nombre,
                Descripcion = n.Descripcion,
                Eliminado = n.Eliminado
            }).ToList(); 
        }


        public async Task<Norma> ObtenerNorma(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var normas = await _context.Normas
                    .FromSqlRaw("EXEC GD.PA_ObtenerNormaPorId @pN_Id", idParametro)
                    .ToListAsync();

                var normaDA = normas.FirstOrDefault();

                if (normaDA != null)
                {
                    return new Norma()
                    {
                        Id = normaDA.Id,
                        Nombre = normaDA.Nombre,
                        Descripcion = normaDA.Descripcion,
                        Eliminado = normaDA.Eliminado
                    };
                }

                return new Norma(); 
            }
            catch (SqlException)
            {
                return new Norma();
            }
        }
    }
}
