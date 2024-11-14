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
                Id = documento.Id,
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
                doctos = documento.doctos,
                activo = documento.activo,
                descargable = documento.descargable,
                doctoId = documento.doctoId,
                ClasificacionID = documento.ClasificacionID,
                NormaID = documento.NormaID,
                UsuarioID = documento.UsuarioID,
                OficinaUsuarioID = documento.OficinaUsuarioID
            };
        }

        public static Documento ConvertirDTOADocumento(DocumentoDTO documentoDTO)
        {
            return new Documento()
            {
                Id = documentoDTO.Id,
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
                doctos = documentoDTO.doctos,
                activo = documentoDTO.activo,
                descargable = documentoDTO.descargable,
                doctoId = documentoDTO.doctoId,
                UsuarioID=documentoDTO.UsuarioID,
                OficinaUsuarioID = documentoDTO.OficinaUsuarioID
            };
        }

        public static IEnumerable<DocumentoDTO> ConvertirListaDeDocumentosADTO(IEnumerable<Documento> documentos)
        {
            return documentos.Select(d => new DocumentoDTO()
            {

                Id = d.Id,
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
                doctos = d.doctos,
                activo = d.activo,
                descargable = d.descargable,
                doctoId = d.doctoId,
                NormaID = d.NormaID,
                VersionID = d.VersionID,
                ClasificacionID = d.ClasificacionID,
                UsuarioID = d.UsuarioID,
                OficinaUsuarioID = d.OficinaUsuarioID,
                numeroVersion = d.numeroVersion
            });
        }

        public static IEnumerable<DocumentoExtendidoDTO> ConvertirListaDeDocumentosExtendidosADTO(IEnumerable<DocumentoExtendido> documentos)
        {
            return documentos.Select(d => new DocumentoExtendidoDTO()
            {

                Id = d.Id,
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
                doctos = d.doctos,
                activo = d.activo,
                descargable = d.descargable,
                doctoId = d.doctoId,
                NormaID = d.NormaID,
                VersionID = d.VersionID,
                ClasificacionID = d.ClasificacionID,
                Archivo = SaveFiles.GetIFormFile(d.urlVersion),
                urlArchivo = d.urlVersion,
                UsuarioID = d.UsuarioID,
                OficinaUsuarioID = d.OficinaUsuarioID,
                numeroVersion = d.numeroVersion

            });
        }

    }
}
