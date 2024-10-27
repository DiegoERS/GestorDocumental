using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarDoctoBW
    {
        Task<IEnumerable<Docto>> ObtenerDoctos();
        Task<Docto> ObtenerDocto(int id);
        Task<bool> CrearDocto(Docto docto);
        Task<bool> ActualizarDocto(Docto docto);
        Task<bool> EliminarDocto(EliminarRequest eliminarRequest);
    }
}
