using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class UsuarioOficinaRN
    {
        public static (bool, string) ElUsuarioOficinaEsValido(UsuarioOficina usuarioOficina)
        {
            if (usuarioOficina.UsuarioID < 0)
            {
                return (false, "El usuario es requerido.");
            }

            if (usuarioOficina.OficinaID < 0)
            {
                return (false, "La oficina es requerida.");
            }

            return (true, string.Empty);
        }
    }
    
}
