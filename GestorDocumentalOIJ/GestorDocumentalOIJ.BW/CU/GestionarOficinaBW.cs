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
    public class GestionarOficinaBW:IGestionarOficinaBW
    {
        private readonly IGestionarOficinaDA _gestionarOficinaDA;

        public GestionarOficinaBW(IGestionarOficinaDA gestionarOficinaDA)
        {
            _gestionarOficinaDA = gestionarOficinaDA;
        }

        public async Task<bool> ActualizarOficina(Oficina oficina)
        {
            (bool esValido, string mensaje) validacion = OficinaRN.LaOficinaEsValida(oficina);

            if (!validacion.esValido)
                return false;

            return await _gestionarOficinaDA.ActualizarOficina(oficina);
        }

        public async Task<bool> CrearOficina(Oficina oficina)
        {
            (bool esValido, string mensaje) validacion = OficinaRN.LaOficinaEsValida(oficina);
            if (!validacion.esValido)
                return false;

            return await _gestionarOficinaDA.CrearOficina(oficina);
        }


        public async Task<bool> EliminarOficina(int id)
        {
            return await _gestionarOficinaDA.EliminarOficina(id);
        }


        public async Task<Oficina> ObtenerOficinaPorId(int id)
        {
            return await _gestionarOficinaDA.ObtenerOficinaPorId(id);
        }

        public async Task<IEnumerable<Oficina>> ObtenerOficinas()
        {
            return await _gestionarOficinaDA.ObtenerOficinas();
        }

        public async Task<IEnumerable<Oficina>> ObtenerOficinasGestor()
        {
            return await _gestionarOficinaDA.ObtenerOficinasGestor();
        }




    }
}
