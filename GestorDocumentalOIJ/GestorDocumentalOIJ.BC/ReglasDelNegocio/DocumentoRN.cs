using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class DocumentoRN
    {
        public static (bool esValido, string mensaje) ElDocumentoEsValido(Documento documento)
        {
            if (documento == null)
                return (false, "El documento no puede ser nulo");

            if (string.IsNullOrWhiteSpace(documento.Codigo))
                return (false, "El código del documento no puede ser nulo o vacío");

            if (string.IsNullOrWhiteSpace(documento.Asunto))
                return (false, "El asunto del documento no puede ser nulo o vacío");

            if (string.IsNullOrWhiteSpace(documento.Descripcion))
                return (false, "La descripción del documento no puede ser nula o vacía");


            if (documento.CategoriaID <= 0)
                return (false, "La categoría del documento no puede ser menor o igual a cero");

            if (documento.TipoDocumento <= 0)
                return (false, "El tipo de documento no puede ser menor o igual a cero");

            if (documento.OficinaID <= 0)
                return (false, "La oficina del documento no puede ser menor o igual a cero");

            if (documento.EtapaID <= 0)
                return (false, "La etapa del documento no puede ser menor o igual a cero");

            if (documento.SubClasificacionID <= 0)
                return (false, "La subclasificación del documento no puede ser menor o igual a cero");

            if (documento.UsuarioID <= 0)
                return (false, "El usuario del documento no puede ser menor o igual a cero");

            if (documento.OficinaUsuarioID <= 0)
                return (false, "La oficina del usuario del documento no puede ser menor o igual a cero");

            if (documento.doctoId <= 0)
                return (false, "El ID del documento no puede ser menor o igual a cero");


            return (true, string.Empty);
        }
    }

}
