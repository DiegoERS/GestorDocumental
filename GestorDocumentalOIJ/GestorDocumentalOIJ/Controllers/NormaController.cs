using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormaController : ControllerBase
    {
        private readonly IGestionarNormaBW _gestionarNormaBW;

        public NormaController(IGestionarNormaBW gestionarNormaBW)
        {
            _gestionarNormaBW = gestionarNormaBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NormaDTO>>> obtenerNormas()
        {
            return Ok(NormaDTOMapper.ConvertirListaDeNormasADTO(await _gestionarNormaBW.ListarNormas()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NormaDTO>> obtenerNormaPorId(int id)
        {
            return Ok(NormaDTOMapper.ConvertirNormaADTO(await _gestionarNormaBW.ObtenerNorma(id)));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> crearNorma(NormaDTO normaDTO)
        {
            return Ok(await _gestionarNormaBW.CrearNorma(NormaDTOMapper.ConvertirDTOANorma(normaDTO)));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> actualizarNorma(NormaDTO normaDTO)
        {
            return Ok(await _gestionarNormaBW.ActualizarNorma(NormaDTOMapper.ConvertirDTOANorma(normaDTO)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> eliminarNorma(int id)
        {
            return Ok(await _gestionarNormaBW.EliminarNorma(id));
        }

    }
}