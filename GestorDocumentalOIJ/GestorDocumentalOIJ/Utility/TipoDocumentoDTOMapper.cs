using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class TipoDocumentoDTOMapper
    {

        public static TipoDocumentoDTO ConvertirTipoDocumentoADTO(TipoDocumento tipoDocumento)
        {
            return new TipoDocumentoDTO()
            {
                Id = tipoDocumento.Id,
                Nombre = tipoDocumento.Nombre,
                Descripcion = tipoDocumento.Descripcion,
                Eliminado = tipoDocumento.Eliminado,
                UsuarioID = tipoDocumento.UsuarioID,
                OficinaID = tipoDocumento.OficinaID
            };
        }

        public static TipoDocumento ConvertirDTOATipoDocumento(TipoDocumentoDTO tipoDocumentoDTO)
        {
            return new TipoDocumento()
            {
                Id = tipoDocumentoDTO.Id,
                Nombre = tipoDocumentoDTO.Nombre,
                Descripcion = tipoDocumentoDTO.Descripcion,
                Eliminado = tipoDocumentoDTO.Eliminado,
                UsuarioID = tipoDocumentoDTO.UsuarioID,
                OficinaID = tipoDocumentoDTO.OficinaID
            };
        }

        public static IEnumerable<TipoDocumentoDTO> ConvertirListaDeTipoDocumentosADTO(IEnumerable<TipoDocumento> tipoDocumentos)
        {
            return tipoDocumentos.Select(td => new TipoDocumentoDTO()
            {
                Id = td.Id,
                Nombre = td.Nombre,
                Descripcion = td.Descripcion,
                Eliminado = td.Eliminado,
                UsuarioID = td.UsuarioID,
                OficinaID = td.OficinaID
            });
        }
    }
}
