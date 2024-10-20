﻿using GestorDocumentalOIJ.BC.Modelos;
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

        public async Task<bool> EliminarDocumento(int id)
        {
            return await _gestionarDocumentoDA.EliminarDocumento(id);
        }

        public async Task<Documento> obtenerDocumentoPorId(int id)
        {
            return await _gestionarDocumentoDA.obtenerDocumentoPorId(id);
        }

        public async Task<IEnumerable<DocumentoExtendido>> ObtenerDocumentos()
        {
            return await _gestionarDocumentoDA.ObtenerDocumentos();
        }

    }
}
