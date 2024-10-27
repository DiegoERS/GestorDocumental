using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarPermisoDA
    {
        Task<IEnumerable<Permiso>> ObtenerPermisos();
        Task<bool> CrearPermiso(Permiso permiso);
        Task<bool> ActualizarPermiso(Permiso permiso);
        Task<bool> EliminarPermiso(int id);
    }
}
