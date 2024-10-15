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
    public class GestionarTipoDocumentoDA:IGestionarTipoDocumentoDA
    {
        private readonly GestorDocumentalContext _context;
        public GestionarTipoDocumentoDA(GestorDocumentalContext context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarTipoDocumento(TipoDocumento tipoDocumento)
        {
            var idParameter = new SqlParameter("@pN_Id", tipoDocumento.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", tipoDocumento.Nombre);
            var descripcionParameter = new SqlParameter(" @pC_Descripcion", tipoDocumento.Descripcion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", tipoDocumento.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC PA_ActualizarTipoDocumento @pN_Id, @pC_Nombre,  @pC_Descripcion, @pB_Eliminado",
                                             idParameter,
                                             nombreParameter,
                                             descripcionParameter,
                                             eliminadoParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }

        public async Task<bool> CrearTipoDocumento(TipoDocumento tipoDocumento)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", tipoDocumento.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", tipoDocumento.Descripcion);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC  GD.PA_InsertarTipoDocumento @pC_Nombre, @pC_Descripcion",
                                              nombreParameter,
                                              descripcionParameter);

            return resultado > 0;

        }

        public async Task<bool> EliminarTipoDocumento(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC GD.PA_EliminarTipoDocumento @pN_Id", new SqlParameter("@pN_Id", id));

            return resultado > 0;

        }

        public async Task<IEnumerable<TipoDocumento>> ObtenerTipoDocumentos()
        {
            var tiposDocumentos = await _context.TiposDocumentos
          .FromSqlRaw("EXEC GD.PA_ListarTiposDocumento")
          .ToListAsync(); 

            return tiposDocumentos.Select(td => new TipoDocumento
            {
                Id = td.Id,
                Nombre = td.Nombre,
                Descripcion = td.Descripcion,
                Eliminado = td.Eliminado
            }).ToList();
        }

        public async Task<TipoDocumento> ObtenerTipoDocumentoPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var tiposDocumentos = await _context.TiposDocumentos
                    .FromSqlRaw("EXEC GD.PA_ObtenerTipoDocumentoPorId @pN_Id", idParametro)
                    .ToListAsync(); 
                var tipoDocumentoDA = tiposDocumentos.FirstOrDefault();

                if (tipoDocumentoDA != null)
                {
                    return new TipoDocumento()
                    {
                        Id = tipoDocumentoDA.Id,
                        Nombre = tipoDocumentoDA.Nombre,
                        Descripcion = tipoDocumentoDA.Descripcion,
                        Eliminado = tipoDocumentoDA.Eliminado
                    };
                }

                return new TipoDocumento(); 
            }
            catch (SqlException)
            {
                return new TipoDocumento();
            }
        }


    }
}
