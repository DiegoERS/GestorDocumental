﻿using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarPermisoBW:IGestionarPermisoBW
    {
        private readonly IGestionarPermisoDA _gestionarPermisoDA;

        public GestionarPermisoBW(IGestionarPermisoDA gestionarPermisoDA)
        {
            _gestionarPermisoDA = gestionarPermisoDA;
        }

        public async Task<bool> ActualizarPermiso(Permiso permiso)
        {
            return await _gestionarPermisoDA.ActualizarPermiso(permiso);
        }

        public async Task<bool> CrearPermiso(Permiso permiso)
        {
            return await _gestionarPermisoDA.CrearPermiso(permiso);
        }

        public async Task<bool> EliminarPermiso(int id)
        {
            return await _gestionarPermisoDA.EliminarPermiso(id);
        }

        public async Task<IEnumerable<Permiso>> ObtenerPermisos()
        {
            return await _gestionarPermisoDA.ObtenerPermisos();
        }

        public async Task<Permiso> obtenerPermisoPorID(int id)
        {
            return await _gestionarPermisoDA.obtenerPermisoPorID(id);
        }

        public async Task<bool> AsignarPermisoARol(int permisoID, int rolID)
        {
            return await _gestionarPermisoDA.AsignarPermisoARol(permisoID, rolID);
        }

        public async Task<bool> RemoverPermisoARol(int permisoID, int rolID)
        {
            return await _gestionarPermisoDA.RemoverPermisoARol(permisoID, rolID);
        }

        public async Task<bool> AsignarPermisoAOficina(int permisoID, int oficinaID)
        {
            return await _gestionarPermisoDA.AsignarPermisoAOficina(permisoID, oficinaID);
        }

        public async Task<bool> RemoverPermisoAOficina(int permisoID, int oficinaID)
        {
            return await _gestionarPermisoDA.RemoverPermisoAOficina(permisoID, oficinaID);
        }



    }
}