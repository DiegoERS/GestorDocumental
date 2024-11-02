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
    public class GestionarTipoDocumentoBW: IGestionarTipoDocumentoBW
    {
        private readonly IGestionarTipoDocumentoDA _gestionarTipoDocumentoDA;

        public GestionarTipoDocumentoBW(IGestionarTipoDocumentoDA gestionarTipoDocumentoDA)
        {
            _gestionarTipoDocumentoDA = gestionarTipoDocumentoDA;
        }

        public async Task<bool> ActualizarTipoDocumento(TipoDocumento tipoDocumento)
        {
            (bool esValido, string mensaje) validacion= TipoDocumentoRN.ElTipoDocumentoEsValido(tipoDocumento);

            if (!validacion.esValido)
                return false;

            return await _gestionarTipoDocumentoDA.ActualizarTipoDocumento(tipoDocumento);
        }

        public async Task<bool> CrearTipoDocumento(TipoDocumento tipoDocumento)
        {
            (bool esValido, string mensaje) validacion = TipoDocumentoRN.ElTipoDocumentoEsValido(tipoDocumento);

            if (!validacion.esValido)
                return false;

            return await _gestionarTipoDocumentoDA.CrearTipoDocumento(tipoDocumento);
        }

        public async Task<bool> EliminarTipoDocumento(EliminarRequest eliminarRequest)
        {
            return await _gestionarTipoDocumentoDA.EliminarTipoDocumento(eliminarRequest);
        }

        public async Task<IEnumerable<TipoDocumento>> ObtenerTipoDocumentos()
        {
            return await _gestionarTipoDocumentoDA.ObtenerTipoDocumentos();
        }

        public async Task<TipoDocumento> ObtenerTipoDocumentoPorId(int id)
        {
            return await _gestionarTipoDocumentoDA.ObtenerTipoDocumentoPorId(id);
        }
    }
}
