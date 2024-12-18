﻿using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarVersionBW
    {
        Task<IEnumerable<BC.Modelos.Version>> ObtenerVersiones();
        Task<BC.Modelos.Version> ObtenerVersionPorId(int id);
        Task<bool> CrearVersion(BC.Modelos.Version version);
        Task<bool> ActualizarVersion(BC.Modelos.Version version);
        Task<bool> EliminarVersion(EliminarRequest eliminarRequest);
        Task<IEnumerable<BC.Modelos.Version>> obtenerVersionPorDocumentoId(int documentoID);
    }
}
