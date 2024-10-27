using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class NormaDTOMapper
    {
        public static NormaDTO ConvertirNormaADTO(Norma norma)
        {
            return new NormaDTO()
            {
                Id = norma.Id,
                Nombre = norma.Nombre,
                Descripcion = norma.Descripcion,
                Eliminado = norma.Eliminado,
                UsuarioID = norma.UsuarioID,
                OficinaID = norma.OficinaID
            };
        }

        public static Norma ConvertirDTOANorma(NormaDTO normaDTO)
        {
            return new Norma()
            {
                Id = normaDTO.Id,
                Nombre = normaDTO.Nombre,
                Descripcion = normaDTO.Descripcion,
                Eliminado = normaDTO.Eliminado,
                UsuarioID = normaDTO.UsuarioID,
                OficinaID = normaDTO.OficinaID
            };
        }

        public static IEnumerable<NormaDTO> ConvertirListaDeNormasADTO(IEnumerable<Norma> normas)
        {
            return normas.Select(n => new NormaDTO()
            {
                Id = n.Id,
                Nombre = n.Nombre,
                Descripcion = n.Descripcion,
                Eliminado = n.Eliminado,
                UsuarioID = n.UsuarioID,
                OficinaID = n.OficinaID
            });
        }
    }

}
