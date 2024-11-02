using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class EliminarRequestDTOMapper
    {

        public static EliminarRequest ConvertirDTOAEliminarRequest(EliminarRequestDTO eliminarRequestDTO)
        {
            return new EliminarRequest
            {
                ObjetoID = eliminarRequestDTO.ObjetoID,
                UsuarioID = eliminarRequestDTO.UsuarioID,
                OficinaID = eliminarRequestDTO.OficinaID
            };
        }

        public static EliminarRequestDTO ConvertirEliminarRequestADTO(EliminarRequest eliminarRequest)
        {
            return new EliminarRequestDTO
            {
                ObjetoID = eliminarRequest.ObjetoID,
                UsuarioID = eliminarRequest.UsuarioID,
                OficinaID = eliminarRequest.OficinaID
            };
        }
    }
}
