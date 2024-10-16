using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarVersionDA
    {
        Task<IEnumerable<BC.Modelos.Version>> ObtenerVersiones();
        Task<BC.Modelos.Version> obtenerVersionPorId(int id);
        Task<bool> CrearVersion(BC.Modelos.Version version);
        Task<bool> ActualizarVersion(BC.Modelos.Version version);
        Task<bool> EliminarVersion(int id);
    }
}
