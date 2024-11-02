using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class PermisoDTOMapper
    {

        public static PermisoDTO ConvertirPermisoADTO(Permiso permiso)
        {
            return new PermisoDTO()
            {
                Id = permiso.Id,
                Nombre = permiso.Nombre,
                Descripcion = permiso.Descripcion,
                Activo = permiso.Activo
            };
        }

        public static Permiso ConvertirDTOAPermiso(PermisoDTO permisoDTO)
        {
            return new Permiso()
            {
                Id = permisoDTO.Id,
                Nombre = permisoDTO.Nombre,
                Descripcion = permisoDTO.Descripcion,
                Activo = permisoDTO.Activo
            };
        }

        public static IEnumerable<PermisoDTO> ConvertirListaDePermisosADTO(IEnumerable<Permiso> permisos)
        {
            return permisos.Select(p => new PermisoDTO()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Activo = p.Activo
            });
        }
    }

  
}
