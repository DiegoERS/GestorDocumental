using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class ClasificacionDTOMapper
    {

        public static ClasificacionDTO ConvertirClasificacionADTO(Clasificacion clasificacion)
        {
            return new ClasificacionDTO()
            {
                Id = clasificacion.Id,
                Nombre = clasificacion.Nombre,
                Descripcion = clasificacion.Descripcion,
                Eliminado = clasificacion.Eliminado,
                UsuarioID = clasificacion.UsuarioID,
                OficinaID = clasificacion.OficinaID
            };
        }

        public static Clasificacion ConvertirDTOAClasificacion(ClasificacionDTO clasificacionDTO)
        {
            return new Clasificacion()
            {
                Id = clasificacionDTO.Id,
                Nombre = clasificacionDTO.Nombre,
                Descripcion = clasificacionDTO.Descripcion,
                Eliminado = clasificacionDTO.Eliminado,
                UsuarioID = clasificacionDTO.UsuarioID,
                OficinaID = clasificacionDTO.OficinaID
            };
        }

        public static IEnumerable<ClasificacionDTO> ConvertirListaDeClasificacionesADTO(IEnumerable<Clasificacion> clasificaciones)
        {
            return clasificaciones.Select(c => new ClasificacionDTO()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Eliminado = c.Eliminado,
                UsuarioID = c.UsuarioID,
                OficinaID = c.OficinaID
            });
        }
    }
}
