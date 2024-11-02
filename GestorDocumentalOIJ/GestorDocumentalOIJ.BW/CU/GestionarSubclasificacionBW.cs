using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BC.ReglasDelNegocio;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarSubclasificacionBW:IGestionarSubclasificacionBW
    {
        private readonly IGestionarSubclasificacionDA _gestionarSubclasificacionDA;

        public GestionarSubclasificacionBW(IGestionarSubclasificacionDA gestionarSubclasificacionDA)
        {
            _gestionarSubclasificacionDA = gestionarSubclasificacionDA;
        }

        public async Task<bool> actualizarSubclasificacion(Subclasificacion subclasificacion)
        {
            (bool esValido, string mensaje) validacion = SubclasificacionRN.LaSubclasificacionEsValida(subclasificacion);

            if (!validacion.esValido)
                return false;

            return await _gestionarSubclasificacionDA.actualizarSubclasificacion(subclasificacion);
        }

        public async Task<bool> crearSubclasificacion(Subclasificacion subclasificacion)
        {
            (bool esValido, string mensaje) validacion = SubclasificacionRN.LaSubclasificacionEsValida(subclasificacion);

            if (!validacion.esValido)
                return false;

            return await _gestionarSubclasificacionDA.crearSubclasificacion(subclasificacion);
        }

        public async Task<bool> eliminarSubclasificacion(EliminarRequest eliminarRequest)
        {
            return await _gestionarSubclasificacionDA.eliminarSubclasificacion(eliminarRequest);
        }

        public async Task<IEnumerable<Subclasificacion>> obtenerSubclasificaciones()
        {
            return await _gestionarSubclasificacionDA.obtenerSubclasificaciones();
        }

        public async Task<Subclasificacion> obtenerSubclasificacionPorId(int id)
        {
            return await _gestionarSubclasificacionDA.obtenerSubclasificacionPorId(id);
        }
    }
}
