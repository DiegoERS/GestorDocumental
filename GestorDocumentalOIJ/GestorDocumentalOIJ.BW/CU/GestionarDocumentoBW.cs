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
    public class GestionarDocumentoBW:IGestionarDocumentoBW
    {
        private readonly IGestionarDocumentoDA _gestionarDocumentoDA;

        public GestionarDocumentoBW(IGestionarDocumentoDA gestionarDocumentoDA)
        {
            _gestionarDocumentoDA = gestionarDocumentoDA;
        }

        public async Task<bool> ActualizarDocumento(Documento documento)
        {
            return await _gestionarDocumentoDA.ActualizarDocumento(documento);
        }

        public async Task<bool> CrearDocumento(Documento documento)
        {
            return await _gestionarDocumentoDA.CrearDocumento(documento);
        }

        public async Task<bool> EliminarDocumento(string codigo)
        {
            return await _gestionarDocumentoDA.EliminarDocumento(codigo);
        }

        public async Task<Documento> ObtenerDocumentoPorCodigo(string codigo)
        {
            return await _gestionarDocumentoDA.ObtenerDocumentoPorCodigo(codigo);
        }

        public async Task<IEnumerable<Documento>> ObtenerDocumentos()
        {
            return await _gestionarDocumentoDA.ObtenerDocumentos();
        }

    }
}
