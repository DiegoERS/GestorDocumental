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
    public class GestionarRolBW:IGestionarRolBW
    {
        private readonly IGestionarRolDA _gestionarRolDA;

        public GestionarRolBW(IGestionarRolDA gestionarRolDA)
        {
            _gestionarRolDA = gestionarRolDA;
        }

        public async Task<bool> ActualizarRol(Rol rol)
        {
            return await _gestionarRolDA.ActualizarRol(rol);
        }

        public async Task<bool> CrearRol(Rol rol)
        {
            return await _gestionarRolDA.CrearRol(rol);
        }


        public async Task<bool> EliminarRol(int id)
        {
            return await _gestionarRolDA.EliminarRol(id);
        }




        public async Task<Rol> ObtenerRolPorId(int id)
        {
            return await _gestionarRolDA.ObtenerRolPorId(id);
        }


        public async Task<IEnumerable<Rol>> ObtenerRoles()
        {
            return await _gestionarRolDA.ObtenerRoles();
        }


    }
}
