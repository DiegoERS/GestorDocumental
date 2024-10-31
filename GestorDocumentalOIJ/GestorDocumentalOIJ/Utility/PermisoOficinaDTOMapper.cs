using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class PermisoOficinaDTOMapper
    {

        public static PermisoOficinaDTO ConvertirPermisoOficinaADTO(PermisoOficina permisoOficina)
        {
            return new PermisoOficinaDTO()
            {
                PermisoID = permisoOficina.PermisoID,
                OficinaID = permisoOficina.OficinaID
            };
        }

        public static PermisoOficina ConvertirDTOAPermisoOficina(PermisoOficinaDTO permisoOficinaDTO)
        {
            return new PermisoOficina()
            {
                PermisoID = permisoOficinaDTO.PermisoID,
                OficinaID = permisoOficinaDTO.OficinaID
            };
        }

        public static IEnumerable<PermisoOficinaDTO> ConvertirListaDePermisosOficinasADTO(IEnumerable<PermisoOficina> permisosOficinas)
        {
            return permisosOficinas.Select(po => new PermisoOficinaDTO()
            {
                PermisoID = po.PermisoID,
                OficinaID = po.OficinaID
            });
        }

    }
}
