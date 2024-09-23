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
            var idParameter = new SqlParameter("@Id", norma.Id);
            var nombreParameter = new SqlParameter("@Nombre", norma.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", norma.Descripcion);
            var eliminadoParameter = new SqlParameter("@Eliminado", norma.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC sp_ActualizarNorma @Id, @Nombre, @Descripcion, @Eliminado",
                                              idParameter,
                                              nombreParameter,
                                              descripcionParameter,
                                              eliminadoParameter );

            // Devuelve true si se afectó al menos una fila
            return resultado == 0;
        }

        public async Task<bool> CrearNorma(Norma norma)
        {
            var nombreParameter = new SqlParameter("@Nombre", norma.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", norma.Descripcion);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC  sp_InsertarNorma @Nombre, @Descripcion",
                                              nombreParameter,
                                              descripcionParameter );

            return resultado == 0;

        }


        public async Task<bool> EliminarNorma(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                          "EXEC sp_EliminarNorma @Id", new SqlParameter("@Id", id));

            return resultado == 0;

        }


        public async Task<IEnumerable<Norma>> ListarNormas()
        {
            return await _context.Normas
            .FromSqlRaw("EXEC sp_ListarNormas")
            .Select(n => new Norma
            {
                Id = n.Id,
                Nombre = n.Nombre,
                Descripcion = n.Descripcion,
                Eliminado = n.Eliminado
            })
            .ToListAsync();
        }


        public async Task<Norma> ObtenerNorma(int id)
        {
            var idParametro = new SqlParameter("@Id", id);

            var normaDA = await _context.Normas
                .FromSqlRaw("EXEC sp_ObtenerNormaPorId @Id", idParametro)
                .FirstOrDefaultAsync();

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
    }
}
