using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public class BitacoraMovimientoDTOMapper
    {
        public static BitacoraMovimiento ConvertirDTOABitacoraMovimiento(BitacoraMovimientoDTO bitacoraMovimientoDTO)
        {
            return new BitacoraMovimiento()
            {
                FechaIngreso = bitacoraMovimientoDTO.FechaIngreso,
                IdMovimiento = bitacoraMovimientoDTO.IdMovimiento,
                Movimiento = bitacoraMovimientoDTO.Movimiento,
                UsuarioID = bitacoraMovimientoDTO.UsuarioID,
                VersionID = bitacoraMovimientoDTO.VersionID
            };
        }
    }
}
