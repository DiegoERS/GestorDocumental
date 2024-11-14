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
            var idParameter = new SqlParameter("@pN_Id", etapa.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", etapa.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", etapa.Descripcion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", etapa.eliminado);
            var normaIDParameter = new SqlParameter("@pN_NormaID", etapa.normaID);
            var etapaIDParameter = new SqlParameter("@pN_EtapaPadreID", etapa.EtapaPadreID);
            var colorParameter = new SqlParameter("@pC_Color", etapa.color);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", etapa.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", etapa.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC GD.PA_ActualizarEtapa @pN_Id, @pC_Nombre, @pC_Descripcion, @pB_Eliminado, @pN_EtapaPadreID, @pC_Color, @pN_NormaID, @pN_UsuarioID, @pN_OficinaID",
                                               idParameter,
                                               nombreParameter,
                                               descripcionParameter,
                                               eliminadoParameter,
                                               etapaIDParameter,
                                               colorParameter,
                                               normaIDParameter,
                                               usuarioIDParameter,
                                               oficinaIDParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }

        public async Task<bool> CrearEtapa(Etapa etapa)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", etapa.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", etapa.Descripcion);
            var normaIDParameter = new SqlParameter("@pN_NormaID", etapa.normaID);
            var etapaPadreIdParameter = new SqlParameter("@pN_EtapaPadreID", etapa.EtapaPadreID);
            var colorParameter = new SqlParameter("@pC_Color", etapa.color);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", etapa.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", etapa.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC  GD.PA_InsertarEtapa @pC_Nombre, @pC_Descripcion, @pN_EtapaPadreID, @pC_Color, @pN_NormaID, @pN_UsuarioID, @pN_OficinaID",
                                                             nombreParameter,
                                                             descripcionParameter,
                                                             etapaPadreIdParameter,
                                                             colorParameter,
                                                             normaIDParameter,
                                                             usuarioIDParameter,
                                                             oficinaIDParameter);
            return resultado > 0;
        }

        public async Task<bool> EliminarEtapa(EliminarRequest eliminarRequest)
        {
            var idParametro = new SqlParameter("@pN_Id", eliminarRequest.ObjetoID);
            var usuarioIDParametro = new SqlParameter("@pN_UsuarioID", eliminarRequest.UsuarioID);
            var oficinaIDParametro = new SqlParameter("@pN_OficinaID", eliminarRequest.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC GD.PA_EliminarEtapa @pN_Id, @pN_UsuarioID, @pN_OficinaID", 
                                                             idParametro,
                                                             usuarioIDParametro,
                                                             oficinaIDParametro);

            return resultado > 0;
        }

        public async Task<IEnumerable<Etapa>> ObtenerEtapas()
        {
 
            var etapas = await _context.Etapas
                .FromSqlRaw("EXEC GD.PA_ListarEtapas")
                .ToListAsync(); 

            return etapas.Select(e => new Etapa
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                eliminado = e.eliminado,
                color = e.color,
                EtapaPadreID = e.EtapaPadreID,
                normaID = e.normaID,
                Consecutivo = e.Consecutivo
            }).ToList(); 
        }

        public async Task<IEnumerable<Etapa>> ObtenerEtapasHuerfanas()
        {

            var etapas = await _context.Etapas
                .FromSqlRaw("EXEC GD.PA_ListarEtapasHuerfanas")
                .ToListAsync();

            return etapas.Select(e => new Etapa
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                eliminado = e.eliminado,
                color = e.color,
                EtapaPadreID = e.EtapaPadreID,
                normaID = e.normaID,
                Consecutivo = e.Consecutivo
            }).ToList();
        }

        public async Task<IEnumerable<Etapa>> ObtenerEtapasPorNorma(int normaId)
        {
            var normaIdParametro = new SqlParameter("@pN_NormaID", normaId);

            var etapas = await _context.Etapas
                .FromSqlRaw("EXEC GD.PA_ObtenerEtapasPorNormaId @pN_NormaID", normaIdParametro)
                .ToListAsync();

            return etapas.Select(e => new Etapa
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                eliminado = e.eliminado,
                color = e.color,
                EtapaPadreID = e.EtapaPadreID,
                normaID = e.normaID,
                Consecutivo = e.Consecutivo
            }).ToList();
        }

        public async Task<Etapa> ObtenerEtapaPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@Id", id);

                var etapas = await _context.Etapas
                    .FromSqlRaw("EXEC GD.PA_ObtenerEtapaPorId @Id", idParametro)
                    .ToListAsync(); 
                var etapaDA = etapas.FirstOrDefault();

                if (etapaDA != null)
                {
                    return new Etapa()
                    {
                        Id = etapaDA.Id,
                        Nombre = etapaDA.Nombre,
                        Descripcion = etapaDA.Descripcion,
                        eliminado = etapaDA.eliminado,
                        color = etapaDA.color,
                        EtapaPadreID=etapaDA.EtapaPadreID,
                        normaID = etapaDA.normaID,
                        Consecutivo = etapaDA.Consecutivo
                    };
                }

                return new Etapa();
            }
            catch (SqlException)
            {
                return new Etapa();
            }
        }
    }
}
