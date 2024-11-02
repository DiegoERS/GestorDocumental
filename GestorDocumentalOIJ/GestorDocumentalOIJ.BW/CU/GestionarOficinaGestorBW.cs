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
    public class GestionarOficinaGestorBW:IGestionarOficinaGestorBW
    {
        private readonly IGestionarOficinaGestorDA _gestionarOficinaGestorDA;

        public GestionarOficinaGestorBW(IGestionarOficinaGestorDA gestionarOficinaGestorDA)
        {
            _gestionarOficinaGestorDA = gestionarOficinaGestorDA;
        }

        public async Task<IEnumerable<OficinaGestor>> obtenerOficinasGestores()
        {
            return await _gestionarOficinaGestorDA.obtenerOficinasGestores();
        }
        public async Task<bool> AsignarOficinaAGestor(OficinaGestor oficinaGestor)
        {
            return await _gestionarOficinaGestorDA.AsignarOficinaAGestor(oficinaGestor);
        }


        public async Task<bool> RemoverOficinaAGestor(OficinaGestor oficinaGestor)
        {
            return await _gestionarOficinaGestorDA.RemoverOficinaAGestor(oficinaGestor);
        }
    }
}