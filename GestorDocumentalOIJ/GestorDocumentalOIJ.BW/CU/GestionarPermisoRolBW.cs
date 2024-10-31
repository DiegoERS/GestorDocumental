using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarPermisoRolBW:IGestionarPermisoRolBW
    {
        private readonly IGestionarPermisoRolDA _gestionarPermisoRolDA;

        public GestionarPermisoRolBW(IGestionarPermisoRolDA gestionarPermisoRolDA)
        {
            _gestionarPermisoRolDA = gestionarPermisoRolDA;
        }

        public async Task<IEnumerable<PermisoRol>> ObtenerPermisosRol()
        {
            return await _gestionarPermisoRolDA.ObtenerPermisosRol();
        }

        public async Task<bool> AsignarPermisoARol(PermisoRol permisoRol)
        {
            return await _gestionarPermisoRolDA.AsignarPermisoARol(permisoRol);
        }

        public async Task<bool> RemoverPermisoARol(PermisoRol permisoRol)
        {
            return await _gestionarPermisoRolDA.RemoverPermisoARol(permisoRol);
        }
    }
}
