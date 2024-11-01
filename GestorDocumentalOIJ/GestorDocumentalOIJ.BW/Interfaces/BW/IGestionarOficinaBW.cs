using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarOficinaBW
    {
        Task<IEnumerable<Oficina>> ObtenerOficinas();
        Task<IEnumerable<Oficina>> ObtenerOficinasGestor();
        Task<Oficina> ObtenerOficinaPorId(int id);
        Task<bool> CrearOficina(Oficina oficina);
        Task<bool> ActualizarOficina(Oficina oficina);
        Task<bool> EliminarOficina(int id);
    }
}
