using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarOficinaDA
    {
        Task<IEnumerable<Oficina>> ObtenerOficinas();
        Task<IEnumerable<Oficina>> ObtenerOficinasGestor();
        Task<Oficina> ObtenerOficinaPorId(int id);
        Task<bool> CrearOficina(Oficina oficina);
        Task<bool> ActualizarOficina(Oficina oficina);
        Task<bool> EliminarOficina(int id);

        Task<bool> AsignarOficinaAGestor(int gestorID, int oficinaID);

        Task<bool> RemoverOficinaAGestor(int gestorID, int oficinaID);
    }
}
