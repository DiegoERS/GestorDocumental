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
    public class GestionarEtapaDA:IGestionarEtapaDA
    {
        private readonly GestorDocumentalContext _context;
        public GestionarEtapaDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarEtapa(Etapa etapa)
        {
            var idParameter = new SqlParameter("@Id", etapa.Id);
            var nombreParameter = new SqlParameter("@Nombre", etapa.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", etapa.Descripcion);
            var eliminadoParameter = new SqlParameter("@Eliminado", etapa.eliminado);
            var normaIDParameter = new SqlParameter("@NormaID", etapa.normaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC sp_ActualizarEtapa @Id, @Nombre, @Descripcion, @Eliminado, @NormaID",
                                               idParameter,
                                               nombreParameter,
                                               descripcionParameter,
                                               eliminadoParameter,
                                               normaIDParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado == 0;
        }

        public async Task<bool> CrearEtapa(Etapa etapa)
        {
            var nombreParameter = new SqlParameter("@Nombre", etapa.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", etapa.Descripcion);
            var normaIDParameter = new SqlParameter("@NormaID", etapa.normaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC  sp_InsertarEtapa @Nombre, @Descripcion, @NormaID",
                                                             nombreParameter,
                                                             descripcionParameter,
                                                             normaIDParameter);
            return resultado == 0;
        }

        public async Task<bool> EliminarEtapa(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC sp_EliminarEtapa @Id", new SqlParameter("@Id", id));

            return resultado == 0;
        }

        public async Task<IEnumerable<Etapa>> ObtenerEtapas()
        {
            return await _context.Etapas
            .FromSqlRaw("EXEC sp_ListarEtapas")
            .Select(e => new Etapa
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                eliminado = e.eliminado,
                normaID = e.normaID
            })
            .ToListAsync();
        }

        public async Task<Etapa> ObtenerEtapaPorId(int id)
        {
            var idParametro = new SqlParameter("@Id", id);

            var etapaDA = await _context.Etapas
                .FromSqlRaw("EXEC sp_ObtenerEtapaPorId @Id", idParametro)
                .FirstOrDefaultAsync();

            if (etapaDA != null)
            {
                return new Etapa()
                {
                    Id = etapaDA.Id,
                    Nombre = etapaDA.Nombre,
                    Descripcion = etapaDA.Descripcion,
                    eliminado = etapaDA.eliminado,
                    normaID = etapaDA.normaID
                };

            }

            return new Etapa();
        }
    }
}
