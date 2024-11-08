using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarBitacoraMovimientoBW : IGestionarBitacoraMovimientoBW
    {
        private readonly IGestionarBitacoraMovimientoDA _gestionarBitacoraMovimientoDA;

        public GestionarBitacoraMovimientoBW(IGestionarBitacoraMovimientoDA gestionarBitacoraMovimientoDA)
        {
            _gestionarBitacoraMovimientoDA = gestionarBitacoraMovimientoDA;
        }

        public async Task<bool> InsertarBitacoraMovimiento(BitacoraMovimiento bitacoraMovimiento)
        {
            return await _gestionarBitacoraMovimientoDA.InsertarBitacoraMovimiento(bitacoraMovimiento);
        }
    }
}
