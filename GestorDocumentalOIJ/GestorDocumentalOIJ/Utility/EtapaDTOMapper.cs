using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class EtapaDTOMapper
    {
        public static EtapaDTO ConvertirEtapaADTO(Etapa etapa)
        {
            return new EtapaDTO()
            {
                Id = etapa.Id,
                Nombre = etapa.Nombre,
                Descripcion = etapa.Descripcion,
                Eliminado = etapa.eliminado,
                normaID = etapa.normaID,
                EtapaPadreID = etapa.EtapaPadreID,
                color = etapa.color,
                UsuarioID = etapa.UsuarioID,
                OficinaID = etapa.OficinaID,
                Consecutivo = etapa.Consecutivo
            };
        }

        public static Etapa ConvertirDTOAEtapa(EtapaDTO etapaDTO)
        {
            return new Etapa()
            {
                Id = etapaDTO.Id,
                Nombre = etapaDTO.Nombre,
                Descripcion = etapaDTO.Descripcion,
                eliminado = etapaDTO.Eliminado,
                normaID = etapaDTO.normaID,
                EtapaPadreID = etapaDTO.EtapaPadreID,
                color = etapaDTO.color,
                UsuarioID = etapaDTO.UsuarioID,
                OficinaID = etapaDTO.OficinaID,
                Consecutivo = etapaDTO.Consecutivo
            };
        }

        public static IEnumerable<EtapaDTO> ConvertirListaDeEtapasADTO(IEnumerable<Etapa> etapas)
        {
            return etapas.Select(e => new EtapaDTO()
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Eliminado = e.eliminado,
                normaID = e.normaID,
                EtapaPadreID= e.EtapaPadreID,
                color = e.color,
                UsuarioID = e.UsuarioID,
                OficinaID = e.OficinaID,
                Consecutivo = e.Consecutivo
            });
        }
    }
}
