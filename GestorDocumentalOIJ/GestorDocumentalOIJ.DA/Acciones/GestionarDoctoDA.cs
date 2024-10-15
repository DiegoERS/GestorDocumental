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
    public class GestionarDoctoDA : IGestionarDoctoDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarDoctoDA(GestorDocumentalContext context)
        {
            _context = context;
        }

      
        public async Task<bool> ActualizarDocto(Docto docto)
        {
            var idParameter = new SqlParameter("@Id", docto.Id);
            var nombreParameter = new SqlParameter("@Nombre", docto.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", docto.Descripcion);
            var eliminadoParameter = new SqlParameter("@Eliminado", docto.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC sp_ActualizarDocto @Id, @Nombre, @Descripcion, @Eliminado",
                                                                                           idParameter,
                                                                                                                                        nombreParameter,
                                                                                                                                                                                     descripcionParameter,
                                                                                                                                                                                                                                  eliminadoParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }


        public async Task<bool> CrearDocto(Docto docto)
        {
            var nombreParameter = new SqlParameter("@Nombre", docto.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", docto.Descripcion);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC  sp_InsertarDocto @Nombre, @Descripcion",
                                                                                                          nombreParameter,
                                                                                                                                                       descripcionParameter);

            return resultado > 0;

        }


        public async Task<bool> EliminarDocto(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                         "EXEC sp_EliminarDocto @Id", new SqlParameter("@Id", id));

            return resultado > 0;

        }

        public async Task<IEnumerable<Docto>> ObtenerDoctos()
        {
            var doctos = await _context.Doctos
         .FromSqlRaw("EXEC sp_ListarDoctos")
         .ToListAsync();
            return doctos.Select(d => new Docto
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Descripcion = d.Descripcion,
                Eliminado = d.Eliminado
            }).ToList();
        }

        public async Task<Docto> ObtenerDocto(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@Id", id);

                var doctos = await _context.Doctos
                    .FromSqlRaw("EXEC sp_ObtenerDoctoPorId @Id", idParametro)
                    .ToListAsync();

                var doctoDA = doctos.FirstOrDefault();

                if (doctoDA != null)
                {
                    return new Docto()
                    {
                        Id = doctoDA.Id,
                        Nombre = doctoDA.Nombre,
                        Descripcion = doctoDA.Descripcion,
                        Eliminado = doctoDA.Eliminado
                    };
                }

                return new Docto();
            }
            catch (SqlException)
            {
                return new Docto();
            }
        }
    }
}
