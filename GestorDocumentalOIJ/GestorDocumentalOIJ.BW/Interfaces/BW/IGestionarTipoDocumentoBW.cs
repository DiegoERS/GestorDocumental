using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarTipoDocumentoBW
    {
        Task<IEnumerable<TipoDocumento>> ObtenerTipoDocumentos();
        Task<TipoDocumento> ObtenerTipoDocumentoPorId(int id);
        Task<bool> CrearTipoDocumento(TipoDocumento tipoDocumento);
        Task<bool> ActualizarTipoDocumento(TipoDocumento tipoDocumento);
        Task<bool> EliminarTipoDocumento(EliminarRequest eliminarRequest);
    }
}
