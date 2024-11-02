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
    public class GestionarPermisoOficinaBW : IGestionarPermisoOficinaBW
    {
        private readonly IGestionarPermisoOficinaDA _gestionarPermisoOficinaDA;

        public GestionarPermisoOficinaBW(IGestionarPermisoOficinaDA gestionarPermisoOficinaDA)
        {
            _gestionarPermisoOficinaDA = gestionarPermisoOficinaDA;
        }

        public async Task<IEnumerable<PermisoOficina>> ObtenerPermisosOficina()
        {
            return await _gestionarPermisoOficinaDA.ObtenerPermisosOficina();
        }

        public async Task<bool> AsignarPermisoAOficina(PermisoOficina permisoOficina)
        {
            (bool esValido, string mensaje) validacion = PermisoOficinaRN.ElPermisoOficinaEsValido(permisoOficina);

            if (!validacion.esValido)
                return false;

            return await _gestionarPermisoOficinaDA.AsignarPermisoAOficina(permisoOficina);
        }

        public async Task<bool> RemoverPermisoAOficina(PermisoOficina permisoOficina)
        {
            (bool esValido, string mensaje) validacion = PermisoOficinaRN.ElPermisoOficinaEsValido(permisoOficina);

            if (!validacion.esValido)
                return false;

            return await _gestionarPermisoOficinaDA.RemoverPermisoAOficina(permisoOficina);
        }


    }
}
