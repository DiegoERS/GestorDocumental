using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class UsuarioOficinaDTOMapper
    {

        public static UsuarioOficinaDTO ConvertirUsuarioOficinaADTO(UsuarioOficina usuarioOficina)
        {
            return new UsuarioOficinaDTO()
            {
                UsuarioID = usuarioOficina.UsuarioID,
                OficinaID = usuarioOficina.OficinaID
            };
        }
        public static UsuarioOficina ConvertirDTOAUsuarioOficina(UsuarioOficinaDTO usuarioOficinaDTO)
        {
            return new UsuarioOficina()
            {
                UsuarioID = usuarioOficinaDTO.UsuarioID,
                OficinaID = usuarioOficinaDTO.OficinaID
            };
        }
        public static IEnumerable<UsuarioOficinaDTO> ConvertirListaDeUsuariosOficinasADTO(IEnumerable<UsuarioOficina> usuariosOficinas)
        {
            return usuariosOficinas.Select(uo => new UsuarioOficinaDTO()
            {
                UsuarioID = uo.UsuarioID,
                OficinaID = uo.OficinaID
            });
        }
    }
}
