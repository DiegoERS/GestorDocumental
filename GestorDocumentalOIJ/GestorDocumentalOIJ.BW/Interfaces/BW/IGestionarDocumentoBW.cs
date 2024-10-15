using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarDocumentoBW
    {
        Task<IEnumerable<Documento>> ObtenerDocumentos();
        Task<Documento> ObtenerDocumentoPorCodigo(string codigo);
        Task<bool> CrearDocumento(Documento documento);
        Task<bool> ActualizarDocumento(Documento documento);
        Task<bool> EliminarDocumento(string codigo);


    }
}
