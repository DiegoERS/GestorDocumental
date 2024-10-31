using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using GestorDocumentalOIJ.DA.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarPermisoOficinaDA : IGestionarPermisoOficinaDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarPermisoOficinaDA(GestorDocumentalContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PermisoOficina>> ObtenerPermisosOficina()
        {
            var permisosOficina = await _context.Set<PermisoOficinaDA>()
                .FromSqlRaw("EXEC SC.PA_ListarPermisoOficina")
                .ToListAsync();
            return permisosOficina.Select(po => new PermisoOficina
            {
                PermisoID = po.PermisoID,
                OficinaID = po.OficinaID
            }).ToList();
        }

        public async Task<bool> AsignarPermisoAOficina(PermisoOficina permisoOficina)
        {
            var permisoParameter = new SqlParameter("@pN_PermisoID", permisoOficina.PermisoID);
            var oficinaParameter = new SqlParameter("@pN_OficinaID", permisoOficina.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync("EXEC SC.PA_InsertarPermisoOficina @pN_PermisoID, @pN_OficinaID",
                                                                        permisoParameter,
                                                                        oficinaParameter);

            return resultado > 0;
        }


        public async Task<bool> RemoverPermisoAOficina(PermisoOficina permisoOficina)
        {
            var permisoParameter = new SqlParameter("@pN_PermisoID", permisoOficina.PermisoID);
            var oficinaParameter = new SqlParameter("@pN_OficinaID", permisoOficina.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync("EXEC SC.PA_EliminarPermisoOficina @pN_PermisoID, @pN_OficinaID",
                                                                         permisoParameter,
                                                                         oficinaParameter);

            return resultado > 0;
        }
    }
}
