using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarNormaUsuarioBW:IGestionarNormaUsuarioBW
    {
        private readonly IGestionarNormaUsuarioDA _gestionarNormaUsuarioDA;

        public GestionarNormaUsuarioBW(IGestionarNormaUsuarioDA gestionarNormaUsuarioDA)
        {
            _gestionarNormaUsuarioDA = gestionarNormaUsuarioDA;
        }

        public async Task<bool> AsignarNormaUsuario(NormaUsuario normaUsuario)
        {
            return await _gestionarNormaUsuarioDA.AsignarNormaUsuario(normaUsuario);
        }

        public async Task<bool> EliminarNormaUsuario(NormaUsuario normaUsuario)
        {
            return await _gestionarNormaUsuarioDA.EliminarNormaUsuario(normaUsuario);
        }
    }
}
