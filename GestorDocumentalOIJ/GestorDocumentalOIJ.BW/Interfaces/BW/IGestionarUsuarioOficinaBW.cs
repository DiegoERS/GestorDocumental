using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarUsuarioOficinaBW
    {
        Task<IEnumerable<UsuarioOficina>> ObtenerUsuariosOficinas();
        Task<bool> AsignarUsuarioAOficina(UsuarioOficina usuarioOficina);

        Task<bool> RemoverUsuarioAOficina(UsuarioOficina usuarioOficina);
    }
}
