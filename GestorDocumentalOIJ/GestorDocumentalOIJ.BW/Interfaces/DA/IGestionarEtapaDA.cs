﻿using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarEtapaDA
    {
        Task<IEnumerable<Etapa>> ObtenerEtapas();
        Task<Etapa> ObtenerEtapaPorId(int id);
        Task<bool> CrearEtapa(Etapa etapa);
        Task<bool> ActualizarEtapa(Etapa etapa);
        Task<bool> EliminarEtapa(int id);
    }
}
