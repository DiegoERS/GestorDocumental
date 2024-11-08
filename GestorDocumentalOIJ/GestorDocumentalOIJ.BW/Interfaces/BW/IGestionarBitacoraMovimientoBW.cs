using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarBitacoraMovimientoBW
    {
        Task<bool> InsertarBitacoraMovimiento(BitacoraMovimiento bitacoraMovimiento);
    }
}
