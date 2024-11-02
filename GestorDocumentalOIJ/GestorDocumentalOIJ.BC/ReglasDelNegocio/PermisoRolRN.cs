using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class PermisoRolRN
    {
        public static (bool esValido, string mensaje) ElPermisoRolEsValido(PermisoRol permisoRol)
        {
            if (permisoRol.RolID < 0)
                return (false, "El rol es requerido");

            if (permisoRol.PermisoID < 0)
                return (false, "El permiso es requerido");

            return (true, string.Empty);
        }

    }
}
