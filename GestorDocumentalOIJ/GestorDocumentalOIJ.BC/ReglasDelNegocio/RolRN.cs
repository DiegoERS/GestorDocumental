using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class RolRN
    {
        public static (bool esValido, string mensaje) ElRolEsValido(Rol rol)
        {
            if (string.IsNullOrWhiteSpace(rol.Nombre))
                return (false, "El nombre del rol es requerido");

            if (string.IsNullOrWhiteSpace(rol.Descripcion))
                return (false, "La descripción del rol es requerida");

            if (rol.Id < 0)
                return (false, "El id del rol es requerido");


            return (true, string.Empty);
        }
    }
}
