using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class OficinaDTOMapper
    {
        public static OficinaDTO ConvertirOficinaADTO(Oficina oficina)
        {
            return new OficinaDTO()
            {
                Id = oficina.Id,
                Nombre = oficina.Nombre,
                CodigoOficina = oficina.CodigoOficina,
                Gestor = oficina.Gestor,
                Eliminado = oficina.Eliminado
            };
        }

        public static Oficina ConvertirDTOAOficina(OficinaDTO oficinaDTO)
        {
            return new Oficina()
            {
                Id = oficinaDTO.Id,
                Nombre = oficinaDTO.Nombre,
                CodigoOficina = oficinaDTO.CodigoOficina,
                Gestor = oficinaDTO.Gestor,
                Eliminado = oficinaDTO.Eliminado
            };
        }

        public static IEnumerable<OficinaDTO> ConvertirListaDeOficinasADTO(IEnumerable<Oficina> oficinas)
        {
            return oficinas.Select(o => new OficinaDTO()
            {
                Id = o.Id,
                Nombre = o.Nombre,
                CodigoOficina = o.CodigoOficina,
                Gestor = o.Gestor,
                Eliminado = o.Eliminado
            });
        }
    }
}
