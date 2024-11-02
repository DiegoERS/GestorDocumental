using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarClasificacionDA
    {
        Task<bool> CrearClasificacion(Clasificacion clasificacion);
        Task<bool> ActualizarClasificacion(Clasificacion clasificacion);
        Task<bool> EliminarClasificacion(EliminarRequest eliminarRequest);
        Task<IEnumerable<Clasificacion>> ObtenerClasificaciones();

        Task<Clasificacion> ObtenerClasificacionPorId(int id);

    }
}
