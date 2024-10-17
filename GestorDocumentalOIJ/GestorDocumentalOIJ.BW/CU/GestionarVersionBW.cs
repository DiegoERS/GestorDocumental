using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarVersionBW:IGestionarVersionBW
    {
        private readonly IGestionarVersionDA _gestionarVersionDA;

        public GestionarVersionBW(IGestionarVersionDA gestionarVersionDA)
        {
            _gestionarVersionDA = gestionarVersionDA;
        }

        public async Task<bool> ActualizarVersion(BC.Modelos.Version version)
        {
            return await _gestionarVersionDA.ActualizarVersion(version);
        }

        public async Task<bool> CrearVersion(BC.Modelos.Version version)
        {
            return await _gestionarVersionDA.CrearVersion(version);
        }

        public async Task<bool> EliminarVersion(int id)
        {
            return await _gestionarVersionDA.EliminarVersion(id);
        }

        public async Task<BC.Modelos.Version> ObtenerVersionPorId(int id)
        {
            return await _gestionarVersionDA.obtenerVersionPorId(id);
        }

        public async Task<IEnumerable<BC.Modelos.Version>> ObtenerVersiones()
        {
            return await _gestionarVersionDA.ObtenerVersiones();
        }

        public async Task<BC.Modelos.Version> obtenerVersionPorDocumentoId(int documentoID)
        {
            return await _gestionarVersionDA.obtenerVersionPorDocumentoId(documentoID);
        }
    }
}
