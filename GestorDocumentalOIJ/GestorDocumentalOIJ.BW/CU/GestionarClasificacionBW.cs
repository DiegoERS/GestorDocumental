using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarClasificacionBW : IGestionarClasificacionBW
    {
        private readonly IGestionarClasificacionDA _gestionarClasificacionDA;

        public GestionarClasificacionBW(IGestionarClasificacionDA gestionarClasificacionDA)
        {
            _gestionarClasificacionDA = gestionarClasificacionDA;
        }

        public async Task<bool> ActualizarClasificacion(Clasificacion clasificacion)
        {
            return await _gestionarClasificacionDA.ActualizarClasificacion(clasificacion);
        }

        public async Task<bool> CrearClasificacion(Clasificacion clasificacion)
        {
            return await _gestionarClasificacionDA.CrearClasificacion(clasificacion);
        }

        public async Task<bool> EliminarClasificacion(int id)
        {
            return await _gestionarClasificacionDA.EliminarClasificacion(id);
        }

        public async Task<IEnumerable<Clasificacion>> ObtenerClasificaciones()
        {
            return await _gestionarClasificacionDA.ObtenerClasificaciones();
        }

        public async Task<Clasificacion> ObtenerClasificacionPorId(int id)
        {
            return await _gestionarClasificacionDA.ObtenerClasificacionPorId(id);
        }
    }
}
