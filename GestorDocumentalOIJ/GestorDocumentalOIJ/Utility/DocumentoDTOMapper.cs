using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class DocumentoDTOMapper
    {
        public static DocumentoDTO ConvertirDocumentoADTO(Documento documento)
        {
            return new DocumentoDTO()
            {
                Codigo = documento.Codigo,
                Asunto = documento.Asunto,
                Descripcion = documento.Descripcion,
                PalabraClave = documento.PalabraClave,
                CategoriaID = documento.CategoriaID,
                TipoDocumento = documento.TipoDocumento,
                OficinaID = documento.OficinaID,
                Vigencia = documento.Vigencia,
                EtapaID = documento.EtapaID,
                SubClasificacionID = documento.SubClasificacionID,
                Doctos = documento.Doctos
            };
        }

        public static Documento ConvertirDTOADocumento(DocumentoDTO documentoDTO)
        {
            return new Documento()
            {
                Codigo = documentoDTO.Codigo,
                Asunto = documentoDTO.Asunto,
                Descripcion = documentoDTO.Descripcion,
                PalabraClave = documentoDTO.PalabraClave,
                CategoriaID = documentoDTO.CategoriaID,
                TipoDocumento = documentoDTO.TipoDocumento,
                OficinaID = documentoDTO.OficinaID,
                Vigencia = documentoDTO.Vigencia,
                EtapaID = documentoDTO.EtapaID,
                SubClasificacionID = documentoDTO.SubClasificacionID,
                Doctos = documentoDTO.Doctos
            };
        }

        public static IEnumerable<DocumentoDTO> ConvertirListaDeDocumentosADTO(IEnumerable<Documento> documentos)
        {
            return documentos.Select(d => new DocumentoDTO()
            {
                Codigo = d.Codigo,
                Asunto = d.Asunto,
                Descripcion = d.Descripcion,
                PalabraClave = d.PalabraClave,
                CategoriaID = d.CategoriaID,
                TipoDocumento = d.TipoDocumento,
                OficinaID = d.OficinaID,
                Vigencia = d.Vigencia,
                EtapaID = d.EtapaID,
                SubClasificacionID = d.SubClasificacionID,
                Doctos = d.Doctos
            });
        }

    }
}
