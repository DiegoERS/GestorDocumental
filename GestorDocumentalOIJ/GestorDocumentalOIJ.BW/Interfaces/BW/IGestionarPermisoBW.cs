﻿using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarPermisoBW
    {
        Task<IEnumerable<Permiso>> ObtenerPermisos();
        Task<bool> CrearPermiso(Permiso permiso);
        Task<bool> ActualizarPermiso(Permiso permiso);
        Task<bool> EliminarPermiso(int id);
        Task<Permiso> obtenerPermisoPorID(int id);
        Task<bool> AsignarPermisoARol(int permisoID, int rolID);
        Task<bool> RemoverPermisoARol(int permisoID, int rolID);
        Task<bool> AsignarPermisoAOficina(int permisoID, int oficinaID);
        Task<bool> RemoverPermisoAOficina(int permisoID, int oficinaID);
    }
}