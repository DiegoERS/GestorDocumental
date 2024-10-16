using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarDocumentoDA
    {
        Task<IEnumerable<DocumentoExtendido>> ObtenerDocumentos();
        Task<Documento> obtenerDocumentoPorId(int id);
        Task<bool> CrearDocumento(Documento documento);
        Task<bool> ActualizarDocumento(Documento documento);
        Task<bool> EliminarDocumento(int id);
    }
}
