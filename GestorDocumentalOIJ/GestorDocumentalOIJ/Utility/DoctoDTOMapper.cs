using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class DoctoDTOMapper
    {

        public static DoctoDTO ConvertirDoctoADTO(Docto docto)
        {
            return new DoctoDTO()
            {
                Id = docto.Id,
                Nombre = docto.Nombre,
                Descripcion = docto.Descripcion,
                Eliminado = docto.Eliminado,
                UsuarioID = docto.UsuarioID,
                OficinaID = docto.OficinaID
            };
        }

        public static Docto ConvertirDTOADocto(DoctoDTO doctoDTO)
        {
            return new Docto()
            {
                Id = doctoDTO.Id,
                Nombre = doctoDTO.Nombre,
                Descripcion = doctoDTO.Descripcion,
                Eliminado = doctoDTO.Eliminado,
                UsuarioID = doctoDTO.UsuarioID,
                OficinaID = doctoDTO.OficinaID
            };
        }

        public static IEnumerable<DoctoDTO> ConvertirListaDeDoctosADTO(IEnumerable<Docto> doctos)
        {
            return doctos.Select(d => new DoctoDTO()
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Descripcion = d.Descripcion,
                Eliminado = d.Eliminado,
                UsuarioID = d.UsuarioID,
                OficinaID = d.OficinaID
            });
        }
    }
}
