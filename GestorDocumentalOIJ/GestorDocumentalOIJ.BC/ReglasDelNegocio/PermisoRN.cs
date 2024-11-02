using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class PermisoRN
    {
        public static (bool esValido, string mensaje) ElPermisoEsValido(Permiso permiso)
        {
            if (string.IsNullOrWhiteSpace(permiso.Nombre))
                return (false, "El nombre del permiso es requerido");

            if (string.IsNullOrWhiteSpace(permiso.Descripcion))
                return (false, "La descripción del permiso es requerida");

            if (permiso.Id < 0)
                return (false, "El id del permiso es requerido");

            return (true, string.Empty);
        }
    }
}
