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
    public class GestionarDoctoBW:IGestionarDoctoBW
    {
        private readonly IGestionarDoctoDA _gestionarDoctoDA;

        public GestionarDoctoBW(IGestionarDoctoDA gestionarDoctoDA)
        {
            _gestionarDoctoDA = gestionarDoctoDA;
        }

        public async Task<IEnumerable<Docto>> ObtenerDoctos()
        {
            return await _gestionarDoctoDA.ObtenerDoctos();
        }

        public async Task<Docto> ObtenerDocto(int id)
        {
            return await _gestionarDoctoDA.ObtenerDocto(id);
        }

        public async Task<bool> CrearDocto(Docto docto)
        {
            return await _gestionarDoctoDA.CrearDocto(docto);
        }


        public async Task<bool> ActualizarDocto(Docto docto)
        {
            return await _gestionarDoctoDA.ActualizarDocto(docto);
        }

        public async Task<bool> EliminarDocto(int id)
        {
            return await _gestionarDoctoDA.EliminarDocto(id);
        }

    }
}
