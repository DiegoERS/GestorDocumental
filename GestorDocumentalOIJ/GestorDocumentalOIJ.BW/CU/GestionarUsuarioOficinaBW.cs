using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BC.ReglasDelNegocio;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarUsuarioOficinaBW:IGestionarUsuarioOficinaBW
    {
        private readonly IGestionarUsuarioOficinaDA _gestionarUsuarioOficinaDA;

        public GestionarUsuarioOficinaBW(IGestionarUsuarioOficinaDA gestionarUsuarioOficinaDA)
        {
            _gestionarUsuarioOficinaDA = gestionarUsuarioOficinaDA;
        }

        public async Task<IEnumerable<UsuarioOficina>> ObtenerUsuariosOficinas()
        {
            return await _gestionarUsuarioOficinaDA.ObtenerUsuariosOficinas();
        }

        public async Task<bool> AsignarUsuarioAOficina(UsuarioOficina usuarioOficina)
        {
            (bool esValido, string mensaje) validacion = UsuarioOficinaRN.ElUsuarioOficinaEsValido(usuarioOficina);

            if (!validacion.esValido)
                return false;

            return await _gestionarUsuarioOficinaDA.AsignarUsuarioAOficina(usuarioOficina);
        }

        public async Task<bool> RemoverUsuarioAOficina(UsuarioOficina usuarioOficina)
        {
            (bool esValido, string mensaje) validacion = UsuarioOficinaRN.ElUsuarioOficinaEsValido(usuarioOficina);
            if (!validacion.esValido)
                return false;

            return await _gestionarUsuarioOficinaDA.RemoverUsuarioAOficina(usuarioOficina);
        }
    }
}
