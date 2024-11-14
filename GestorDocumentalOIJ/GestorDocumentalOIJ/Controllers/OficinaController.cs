using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficinaController : ControllerBase
    {
        private readonly IGestionarOficinaBW _gestionarOficinaBW;

        public OficinaController(IGestionarOficinaBW gestionarOficinaBW)
        {
            _gestionarOficinaBW = gestionarOficinaBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OficinaDTO>>> ObtenerOficinas()
        {
            return Ok(OficinaDTOMapper.ConvertirListaDeOficinasADTO(await _gestionarOficinaBW.ObtenerOficinas()));
        }
        
        [HttpGet]
        [Route("ObtenerOficinasGestor")]
        public async Task<ActionResult<IEnumerable<OficinaDTO>>> ObtenerOficinasGestor()
        {
            return Ok(OficinaDTOMapper.ConvertirListaDeOficinasADTO(await _gestionarOficinaBW.ObtenerOficinasGestor()));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<OficinaDTO>> ObtenerOficinaPorId(int id)
        {
            return Ok(OficinaDTOMapper.ConvertirOficinaADTO(await _gestionarOficinaBW.ObtenerOficinaPorId(id)));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CrearOficina(OficinaDTO oficinaDTO)
        {
            return Ok(await _gestionarOficinaBW.CrearOficina(OficinaDTOMapper.ConvertirDTOAOficina(oficinaDTO)));
        }

        [HttpPut]

        public async Task<ActionResult<bool>> ActualizarOficina(OficinaDTO oficinaDTO)
        {
            return Ok(await _gestionarOficinaBW.ActualizarOficina(OficinaDTOMapper.ConvertirDTOAOficina(oficinaDTO)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> EliminarOficina(int id)
        {
            return Ok(await _gestionarOficinaBW.EliminarOficina(id));
        }

        [HttpGet]
        [Route("ObtenerOficinasCodigo")]
        public async Task<ActionResult<IEnumerable<OficinaDTO>>> ObtenerOficinasCodigo()
        {
            return Ok(OficinaDTOMapper.ConvertirListaDeOficinasADTO(await _gestionarOficinaBW.ObtenerOficinasCodigo()));
        }

    }
}
