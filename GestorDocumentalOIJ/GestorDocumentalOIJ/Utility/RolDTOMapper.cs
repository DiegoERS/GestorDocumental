using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class RolDTOMapper
    {
        public static RolDTO ConvertirRolADTO(Rol rol)
        {
            return new RolDTO()
            {
                Id = rol.Id,
                Nombre = rol.Nombre,
                Descripcion = rol.Descripcion,
                Activo = rol.Activo
            };
        }

        public static Rol ConvertirDTOARol(RolDTO rolDTO)
        {
            return new Rol()
            {
                Id = rolDTO.Id,
                Nombre = rolDTO.Nombre,
                Descripcion = rolDTO.Descripcion,
                Activo = rolDTO.Activo
            };
        }

        public static IEnumerable<RolDTO> ConvertirListaDeRolesADTO(IEnumerable<Rol> roles)
        {
            return roles.Select(r => new RolDTO()
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                Activo = r.Activo
            });
        }
    }
}
