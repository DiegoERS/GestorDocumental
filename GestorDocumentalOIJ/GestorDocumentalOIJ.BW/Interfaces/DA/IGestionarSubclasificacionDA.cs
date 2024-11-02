using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarSubclasificacionDA
    {

        Task<IEnumerable<Subclasificacion>> obtenerSubclasificaciones();

        Task<Subclasificacion> obtenerSubclasificacionPorId(int id);

        Task<bool> crearSubclasificacion(Subclasificacion subclasificacion);

        Task<bool> actualizarSubclasificacion(Subclasificacion subclasificacion);

        Task<bool> eliminarSubclasificacion(EliminarRequest eliminarRequest);
    }
}
