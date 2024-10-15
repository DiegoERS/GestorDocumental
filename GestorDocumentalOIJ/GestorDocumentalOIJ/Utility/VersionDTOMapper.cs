using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class VersionDTOMapper
    {

        public static VersionDTO ConvertirVersionADTO(BC.Modelos.Version version)
        {
            return new VersionDTO()
            {
                Id = version.Id,
                Nombre = version.Nombre,
                Descripcion = version.Descripcion,
                Eliminado = version.Eliminado
            };
        }

        public static BC.Modelos.Version ConvertirDTOAVersion(VersionDTO versionDTO)
        {
            return new BC.Modelos.Version()
            {
                Id = versionDTO.Id,
                Nombre = versionDTO.Nombre,
                Descripcion = versionDTO.Descripcion,
                Eliminado = versionDTO.Eliminado
            };
        }

        public static IEnumerable<VersionDTO> ConvertirListaDeVersionesADTO(IEnumerable<BC.Modelos.Version> versiones)
        {
            return versiones.Select(v => new VersionDTO()
            {
                Id = v.Id,
                Nombre = v.Nombre,
                Descripcion = v.Descripcion,
                Eliminado = v.Eliminado
            });
        }
    }
}
