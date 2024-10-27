using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarUsuarioDA
    {
        Task<Usuario> ObtenerUsuarioPorId(int idUsuario);

        Task<IEnumerable<Usuario>> ObtenerUsuarios();

        Task<bool> CrearUsuario(Usuario usuario);

        Task<bool> ActualizarUsuario(Usuario usuario);

        Task<bool> EliminarUsuario(int idUsuario);

        Task<bool> Autenticar(string correo, string password);
    }
}
