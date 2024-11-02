﻿using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarPermisoOficinaDA
    {
        Task<IEnumerable<PermisoOficina>> ObtenerPermisosOficina();
        Task<bool> AsignarPermisoAOficina(PermisoOficina permisoOficina);
        Task<bool> RemoverPermisoAOficina(PermisoOficina permisoOficina);
    }
}