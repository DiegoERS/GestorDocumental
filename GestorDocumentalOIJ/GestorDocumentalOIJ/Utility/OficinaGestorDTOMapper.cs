using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class OficinaGestorDTOMapper
    {
        public static OficinaGestorDTO ConvertirOficinaGestorADTO(OficinaGestor oficinaGestor)
        {
            return new OficinaGestorDTO()
            {
                OficinaID = oficinaGestor.OficinaID,
                GestorID = oficinaGestor.GestorID
            };
        }

        public static OficinaGestor ConvertirDTOAOficinaGestor(OficinaGestorDTO oficinaGestorDTO)
        {
            return new OficinaGestor()
            {
                OficinaID = oficinaGestorDTO.OficinaID,
                GestorID = oficinaGestorDTO.GestorID
            };
        }

        public static IEnumerable<OficinaGestorDTO> ConvertirListaDeOficinasGestoresADTO(IEnumerable<OficinaGestor> oficinasGestores)
        {
            return oficinasGestores.Select(og => new OficinaGestorDTO()
            {
                OficinaID = og.OficinaID,
                GestorID = og.GestorID
            });
        }
    }
}
