using GestorDocumentalOIJ.BW.CU;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficinaGestorController : ControllerBase
    {
        private readonly IGestionarOficinaGestorBW _gestionarOficinaGestorBW;

        public OficinaGestorController(IGestionarOficinaGestorBW gestionarOficinaGestorBW)
        {
            _gestionarOficinaGestorBW = gestionarOficinaGestorBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OficinaGestorDTO>>> ObtenerOficinasGestores()
        {
            return Ok(OficinaGestorDTOMapper.ConvertirListaDeOficinasGestoresADTO(await _gestionarOficinaGestorBW.obtenerOficinasGestores()));
        }


        [HttpPost("AsignarOficinaGestor")]
        public async Task<ActionResult<bool>> AsignarOficinaAGestor(OficinaGestorDTO oficinaGestorDTO)
        {
            return Ok(await _gestionarOficinaGestorBW.AsignarOficinaAGestor(OficinaGestorDTOMapper.ConvertirDTOAOficinaGestor(oficinaGestorDTO)));
        }

        [HttpPost("RemoverOficinaGestor")]
        public async Task<ActionResult<bool>> RemoverOficinaAGestor(OficinaGestorDTO oficinaGestorDTO)
        {
            return Ok(await _gestionarOficinaGestorBW.RemoverOficinaAGestor(OficinaGestorDTOMapper.ConvertirDTOAOficinaGestor(oficinaGestorDTO)));
        }
    }
}
