using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class TipoDocumentoRN
    {
        public static (bool esValido, string mensaje) ElTipoDocumentoEsValido(TipoDocumento tipoDocumento)
        {
            if (string.IsNullOrWhiteSpace(tipoDocumento.Nombre))
                return (false, "El nombre del tipo de documento es requerido");

            if (string.IsNullOrWhiteSpace(tipoDocumento.Descripcion))
                return (false, "La descripción del tipo de documento es requerida");

            if (tipoDocumento.Id < 0)
                return (false, "El id del tipo de documento es requerido");

            if (tipoDocumento.UsuarioID < 0)
                return (false, "EL usuario del tipo de documento es requerida");

            if (tipoDocumento.OficinaID < 0)
                return (false, "La oficina del tipo de documento es requerida");

            return (true, string.Empty);
        }
    }
}
