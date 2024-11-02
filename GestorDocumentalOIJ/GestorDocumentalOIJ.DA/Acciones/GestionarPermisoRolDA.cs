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
    public class GestionarPermisoRolDA : IGestionarPermisoRolDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarPermisoRolDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PermisoRol>> ObtenerPermisosRol()
        {
            var permisosRol = await _context.PermisosRoles
                .FromSqlRaw("EXEC SC.PA_ListarPermisoRol")
                .ToListAsync();
            return permisosRol.Select(pr => new PermisoRol
            {

                PermisoID = pr.PermisoID,
                RolID = pr.RolID
            }).ToList();
        }

        public async Task<bool> AsignarPermisoARol(PermisoRol permisoRol)
        {
            var permisoParameter = new SqlParameter("@pN_PermisoID", permisoRol.PermisoID);
            var rolParameter = new SqlParameter("@pN_RolID", permisoRol.RolID);

            int resultado = await _context.Database.ExecuteSqlRawAsync("EXEC SC.PA_InsertarPermisoRol @pN_PermisoID, @pN_RolID",
                                                                        permisoParameter,
                                                                        rolParameter);

            return resultado > 0;
        }
        public async Task<bool> RemoverPermisoARol(PermisoRol permisoRol)
        {
            var permisoParameter = new SqlParameter("@pN_PermisoID", permisoRol.PermisoID);
            var rolParameter = new SqlParameter("@pN_RolID", permisoRol.RolID);

            int resultado = await _context.Database.ExecuteSqlRawAsync("EXEC SC.PA_EliminarPermisoRol @pN_PermisoID, @pN_RolID",
                                                                         permisoParameter,
                                                                         rolParameter);

            return resultado > 0;
        }

    }
}
