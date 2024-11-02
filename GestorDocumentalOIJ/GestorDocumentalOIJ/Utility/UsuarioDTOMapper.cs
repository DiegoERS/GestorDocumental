using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class UsuarioDTOMapper
    {

        public static UsuarioDTO ConvertirUsuarioADTO(Usuario usuario)
        {
            return new UsuarioDTO()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Password = usuario.Password,
                RolID = usuario.RolID,
                Activo = usuario.Activo,
                Eliminado = usuario.Eliminado
            };
        }

        public static Usuario ConvertirDTOAUsuario(UsuarioDTO usuarioDTO)
        {
            return new Usuario()
            {
                Id = usuarioDTO.Id,
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Correo = usuarioDTO.Correo,
                Password = usuarioDTO.Password,
                RolID = usuarioDTO.RolID,
                Activo = usuarioDTO.Activo,
                Eliminado = usuarioDTO.Eliminado
            };
        }

        public static IEnumerable<UsuarioDTO> ConvertirListaDeUsuariosADTO(IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(u => new UsuarioDTO()
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Password = u.Password,
                RolID = u.RolID,
                Activo = u.Activo,
                Eliminado = u.Eliminado
            });
        }
    }
}
