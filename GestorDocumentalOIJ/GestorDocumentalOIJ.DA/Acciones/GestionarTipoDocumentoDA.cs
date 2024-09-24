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
            var idParameter = new SqlParameter("@Id", tipoDocumento.Id);
            var nombreParameter = new SqlParameter("@Nombre", tipoDocumento.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", tipoDocumento.Descripcion);
            var eliminadoParameter = new SqlParameter("@Eliminado", tipoDocumento.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC sp_ActualizarTipoDocumento @Id, @Nombre, @Descripcion, @Eliminado",
                                             idParameter,
                                             nombreParameter,
                                             descripcionParameter,
                                             eliminadoParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }

        public async Task<bool> CrearTipoDocumento(TipoDocumento tipoDocumento)
        {
            var nombreParameter = new SqlParameter("@Nombre", tipoDocumento.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", tipoDocumento.Descripcion);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC  sp_InsertarTipoDocumento @Nombre, @Descripcion",
                                              nombreParameter,
                                              descripcionParameter);

            return resultado > 0;

        }

        public async Task<bool> EliminarTipoDocumento(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC sp_EliminarTipoDocumento @Id", new SqlParameter("@Id", id));

            return resultado > 0;

        }

        public async Task<IEnumerable<TipoDocumento>> ObtenerTipoDocumentos()
        {
            var tiposDocumentos = await _context.TiposDocumentos
          .FromSqlRaw("EXEC sp_ListarTiposDocumento")
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
                var idParametro = new SqlParameter("@Id", id);

                var tiposDocumentos = await _context.TiposDocumentos
                    .FromSqlRaw("EXEC sp_ObtenerTipoDocumentoPorId @Id", idParametro)
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
