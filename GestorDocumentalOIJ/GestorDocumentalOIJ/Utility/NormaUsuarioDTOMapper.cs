using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class NormaUsuarioDTOMapper
    {
        public static NormaUsuarioDTO ConvertirNormaUsuarioADTO(NormaUsuario normaUsuario)
        {
            return new NormaUsuarioDTO()
            {
                NormaID = normaUsuario.NormaID,
                UsuarioID = normaUsuario.UsuarioID
            };
        }

        public static NormaUsuario ConvertirDTOANormaUsuario(NormaUsuarioDTO normaUsuarioDTO)
        {
            return new NormaUsuario()
            {
                NormaID = normaUsuarioDTO.NormaID,
                UsuarioID = normaUsuarioDTO.UsuarioID
            };
        }

        public static IEnumerable<NormaUsuarioDTO> ConvertirListaDeNormasUsuariosADTO(IEnumerable<NormaUsuario> normasUsuarios)
        {
            return normasUsuarios.Select(nu => new NormaUsuarioDTO()
            {
                NormaID = nu.NormaID,
                UsuarioID = nu.UsuarioID
            });
        }
    }
}
