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
    public class GestionarDocumentoBW:IGestionarDocumentoBW
    {
        private readonly IGestionarDocumentoDA _gestionarDocumentoDA;

        public GestionarDocumentoBW(IGestionarDocumentoDA gestionarDocumentoDA)
        {
            _gestionarDocumentoDA = gestionarDocumentoDA;
        }

        public async Task<bool> ActualizarDocumento(Documento documento)
        {
            (bool esValido, string mensaje) validacion = DocumentoRN.ElDocumentoEsValido(documento);
            if (!validacion.esValido)
                return false;

            return await _gestionarDocumentoDA.ActualizarDocumento(documento);
        }

        public async Task<bool> CrearDocumento(Documento documento)
        {
            (bool esValido, string mensaje) validacion = DocumentoRN.ElDocumentoEsValido(documento);
            if (!validacion.esValido)
                return false;

            return await _gestionarDocumentoDA.CrearDocumento(documento);
        }

        public async Task<bool> EliminarDocumento(EliminarRequest eliminarRequest)
        {
            return await _gestionarDocumentoDA.EliminarDocumento(eliminarRequest);
        }

        public async Task<Documento> obtenerDocumentoPorId(int id)
        {
            return await _gestionarDocumentoDA.obtenerDocumentoPorId(id);
        }

        public async Task<IEnumerable<Documento>> ObtenerDocumentos()
        {
            return await _gestionarDocumentoDA.ObtenerDocumentos();
        }

        public async Task<IEnumerable<DocumentoExtendido>> ObtenerConsultaDocumentos()
        {
            return await _gestionarDocumentoDA.ObtenerConsultaDocumentos();
        }

    }
}
