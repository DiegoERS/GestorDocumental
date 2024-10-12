using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarClasificacionBW
    {
        Task<bool> CrearClasificacion(Clasificacion clasificacion);
        Task<bool> ActualizarClasificacion(Clasificacion clasificacion);
        Task<bool> EliminarClasificacion(int id);
        Task<IEnumerable<Clasificacion>> ObtenerClasificaciones();

        Task<Clasificacion> ObtenerClasificacionPorId(int id);
    }
}
