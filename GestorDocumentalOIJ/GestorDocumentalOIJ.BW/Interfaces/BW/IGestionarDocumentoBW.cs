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
        Task<IEnumerable<DocumentoExtendido>> ObtenerConsultaDocumentos(int usuarioID);
        Task<Documento> obtenerDocumentoPorId(int id);
        Task<int> CrearDocumento(Documento documento);
        Task<bool> ActualizarDocumento(Documento documento);
        Task<bool> EliminarDocumento(EliminarRequest eliminarRequest);


    }
}
