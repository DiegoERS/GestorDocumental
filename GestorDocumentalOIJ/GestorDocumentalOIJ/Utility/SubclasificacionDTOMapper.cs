using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class SubclasificacionDTOMapper
    {
        public static SubclasificacionDTO ConvertirSubclasificacionADTO(Subclasificacion subclasificacion)
        {
            return new SubclasificacionDTO()
            {
                Id = subclasificacion.Id,
                Nombre = subclasificacion.Nombre,
                Descripcion = subclasificacion.Descripcion,
                Eliminado = subclasificacion.Eliminado,
                ClasificacionID = subclasificacion.ClasificacionID,
                UsuarioID = subclasificacion.UsuarioID,
                OficinaID = subclasificacion.OficinaID
            };
        }

        public static Subclasificacion ConvertirDTOASubclasificacion(SubclasificacionDTO subclasificacionDTO)
        {
            return new Subclasificacion()
            {
                Id = subclasificacionDTO.Id,
                Nombre = subclasificacionDTO.Nombre,
                Descripcion = subclasificacionDTO.Descripcion,
                Eliminado = subclasificacionDTO.Eliminado,
                ClasificacionID = subclasificacionDTO.ClasificacionID,
                UsuarioID = subclasificacionDTO.UsuarioID,
                OficinaID = subclasificacionDTO.OficinaID
            };
        }

        public static IEnumerable<SubclasificacionDTO> ConvertirListaDeSubclasificacionesADTO(IEnumerable<Subclasificacion> subclasificaciones)
        {
            return subclasificaciones.Select(s => new SubclasificacionDTO()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                Eliminado = s.Eliminado,
                ClasificacionID = s.ClasificacionID,
                UsuarioID = s.UsuarioID,
                OficinaID = s.OficinaID
            });
        }
    }
}
