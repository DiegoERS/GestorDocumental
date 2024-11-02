using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class NormaUsuarioRN
    {
        public static (bool esValido, string mensaje) LaNormaUsuarioEsValida(NormaUsuario normaUsuario)
        {
            if (normaUsuario.UsuarioID < 0)
                return (false, "El usuario es requerido");

            if (normaUsuario.NormaID < 0)
                return (false, "La norma es requerida");

            return (true, string.Empty);
        }
    }
}
