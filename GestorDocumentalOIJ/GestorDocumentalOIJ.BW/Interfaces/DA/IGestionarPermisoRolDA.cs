using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarPermisoRolDA
    {
        Task<IEnumerable<PermisoRol>> ObtenerPermisosRol();
        Task<bool> AsignarPermisoARol(PermisoRol permisoRol);
        Task<bool> RemoverPermisoARol(PermisoRol permisoRol);
       
    }
}
