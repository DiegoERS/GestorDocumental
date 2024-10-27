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
    public class GestionarNormaBW:IGestionarNormaBW
    {
        private readonly IGestionarNormaDA _gestionarNormaDA;

        public GestionarNormaBW(IGestionarNormaDA gestionarNormaDA)
        {
            _gestionarNormaDA = gestionarNormaDA;
        }

        public async Task<bool> ActualizarNorma(Norma norma)
        {
            return await _gestionarNormaDA.ActualizarNorma(norma);
        }

        public async Task<bool> CrearNorma(Norma norma)
        {
            return await _gestionarNormaDA.CrearNorma(norma);
        }

        public async Task<bool> EliminarNorma(EliminarRequest eliminarRequest)
        {
            return await _gestionarNormaDA.EliminarNorma(eliminarRequest);
        }

        public async Task<IEnumerable<Norma>> ListarNormas()
        {
            return await _gestionarNormaDA.ListarNormas();
        }

        public async Task<Norma> ObtenerNorma(int id)
        {
            return await _gestionarNormaDA.ObtenerNorma(id);
        }
    }
}
