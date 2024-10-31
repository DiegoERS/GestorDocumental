using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class PermisoRolDTOMapper
    {

        public static PermisoRolDTO ConvertirPermisoRolADTO(PermisoRol permisoRol)
        {
            return new PermisoRolDTO()
            {
                PermisoID = permisoRol.PermisoID,
                RolID = permisoRol.RolID
            };
        }

        public static PermisoRol ConvertirDTOAPermisoRol(PermisoRolDTO permisoRolDTO)
        {
            return new PermisoRol()
            {
                PermisoID = permisoRolDTO.PermisoID,
                RolID = permisoRolDTO.RolID
            };
        }


        public static IEnumerable<PermisoRolDTO> ConvertirListaDePermisosRolesADTO(IEnumerable<PermisoRol> permisosRoles)
        {
            return permisosRoles.Select(pr => new PermisoRolDTO()
            {
                PermisoID = pr.PermisoID,
                RolID = pr.RolID
            });
        }
    }


    
}
