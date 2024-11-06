using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class PermisoOficinaRN
    {
        
        public static (bool esValido, string mensaje) ElPermisoOficinaEsValido(PermisoOficina permisoOficina)
        {
            if (permisoOficina.OficinaID < 0)
                return (false, "La oficina es requerida");

            if (permisoOficina.PermisoID < 0)
                return (false, "El permiso es requerido");

            return (true, string.Empty);
        }
    }
}
