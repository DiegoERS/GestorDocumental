using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarBitacoraMovimientoDA
    {
        Task<bool> InsertarBitacoraMovimiento(BitacoraMovimiento bitacoraMovimiento);
    }
}
