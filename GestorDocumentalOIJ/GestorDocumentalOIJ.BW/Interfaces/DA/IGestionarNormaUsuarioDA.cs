using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarNormaUsuarioDA
    {
        Task<IEnumerable<NormaUsuario>> ObtenerNormasUsuarios();
        Task<bool> AsignarNormaUsuario(NormaUsuario normaUsuario);
        Task<bool> EliminarNormaUsuario(NormaUsuario normaUsuario);
    }
}
