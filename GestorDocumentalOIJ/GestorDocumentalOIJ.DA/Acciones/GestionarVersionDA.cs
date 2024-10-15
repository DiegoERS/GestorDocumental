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
    public class GestionarVersionDA:IGestionarVersionDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarVersionDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarVersion(BC.Modelos.Version version)
        {
            var idParameter = new SqlParameter("@pN_Id", version.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", version.Nombre);
            var descripcionParameter = new SqlParameter(" @pC_Descripcion", version.Descripcion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", version.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC PA_ActualizarVersion @pN_Id, @pC_Nombre,  @pC_Descripcion, @pB_Eliminado",
                                                                                          idParameter,
                                                                                                                                      nombreParameter,
                                                                                                                                                                                  descripcionParameter,
                                                                                                                                                                                                                              eliminadoParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }

        public async Task<bool> CrearVersion(BC.Modelos.Version version)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", version.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", version.Descripcion);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC  GD.PA_InsertarVersion @pC_Nombre, @pC_Descripcion",
                                                                                                                                                      nombreParameter,
                                                                                                                                                                                                                                                                                                                                       descripcionParameter);

            return resultado > 0;

        }

        public async Task<bool> EliminarVersion(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                                             "EXEC GD.PA_EliminarVersion @pN_Id", new SqlParameter("@pN_Id", id));

            return resultado > 0;

        }

        public async Task<IEnumerable<BC.Modelos.Version>> ObtenerVersiones()
        {
            var versiones = await _context.Versiones
          .FromSqlRaw("EXEC GD.PA_ListarVersiones")
          .ToListAsync();

            return versiones.Select(v => new BC.Modelos.Version
            {
                Id = v.Id,
                Nombre = v.Nombre,
                Descripcion = v.Descripcion,
                Eliminado = v.Eliminado
            }).ToList();
        }


        public async Task<BC.Modelos.Version> ObtenerVersionPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var versiones = await _context.Versiones
                    .FromSqlRaw("EXEC GD.PA_ObtenerVersionPorId @pN_Id", idParametro)
                    .ToListAsync();
                var versionDA = versiones.FirstOrDefault();

                if (versionDA != null)
                {
                    return new BC.Modelos.Version()
                    {
                        Id = versionDA.Id,
                        Nombre = versionDA.Nombre,
                        Descripcion = versionDA.Descripcion,
                        Eliminado = versionDA.Eliminado
                    };
                }

                return new BC.Modelos.Version();
            }
            catch (SqlException)
            {
                return new BC.Modelos.Version();
            }
        }
    }
}
