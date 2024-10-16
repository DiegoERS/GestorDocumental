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
                DocumentoID = version.DocumentoID,
                NumeroVersion = version.NumeroVersion,
                FechaCreacion = version.FechaCreacion,
                eliminado = version.eliminado,
                usuarioID = version.usuarioID
            };
        }

        public static BC.Modelos.Version ConvertirDTOAVersion(VersionDTO versionDTO, string rutaArchivo)
        {
            return new BC.Modelos.Version()
            {
                Id = versionDTO.Id,
                DocumentoID = versionDTO.DocumentoID,
                NumeroVersion = versionDTO.NumeroVersion,
                FechaCreacion = versionDTO.FechaCreacion,
                urlVersion = rutaArchivo,
                eliminado = versionDTO.eliminado,
                usuarioID = versionDTO.usuarioID
            };
        }

        public static IEnumerable<VersionDTO> ConvertirListaDeVersionesADTO(IEnumerable<BC.Modelos.Version> versiones)
        {
            return versiones.Select(v => new VersionDTO()
            {
                Id = v.Id,
                DocumentoID = v.DocumentoID,
                NumeroVersion = v.NumeroVersion,
                FechaCreacion = v.FechaCreacion,
                eliminado = v.eliminado,
                usuarioID = v.usuarioID

            });
        }
    }
}
