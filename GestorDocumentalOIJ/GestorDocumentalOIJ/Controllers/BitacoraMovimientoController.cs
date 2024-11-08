using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraMovimientoController : ControllerBase
    {
        private readonly IGestionarBitacoraMovimientoBW _gestionarBitacoraMovimientoBW;

        public BitacoraMovimientoController(IGestionarBitacoraMovimientoBW gestionarBitacoraMovimientoBW)
        {
            _gestionarBitacoraMovimientoBW = gestionarBitacoraMovimientoBW;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEnBitacora(BitacoraMovimientoDTO bitacoraMovimientoDTO)
        {
            return Ok(_gestionarBitacoraMovimientoBW.InsertarBitacoraMovimiento(BitacoraMovimientoDTOMapper.ConvertirDTOABitacoraMovimiento(bitacoraMovimientoDTO)));
        }
    }
}
