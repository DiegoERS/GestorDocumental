using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class NormaRN
    {
        public static (bool esValido, string mensaje) LaNormaEsValida(Norma norma)
        {
            if (string.IsNullOrWhiteSpace(norma.Nombre))
                return (false, "El nombre de la norma es requerido");

            if (string.IsNullOrWhiteSpace(norma.Descripcion))
                return (false, "La descripción de la norma es requerida");

            if (norma.UsuarioID < 0)
                return (false, "El usuario es requerido");

            if (norma.OficinaID < 0)
                return (false, "La oficina es requerida");

            if (norma.Id < 0)
                return (false, "El id de la norma es requerido");

            return (true, string.Empty);
        }
    }
}
