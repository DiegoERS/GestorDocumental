using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarOficinaGestorDA
    {
        Task<IEnumerable<OficinaGestor>> obtenerOficinasGestores();
        Task<bool> AsignarOficinaAGestor(OficinaGestor oficinaGestor);

        Task<bool> RemoverOficinaAGestor(OficinaGestor oficinaGestor);
    }
}
