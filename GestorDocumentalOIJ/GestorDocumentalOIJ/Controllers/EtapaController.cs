using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtapaController : ControllerBase
    {
        private readonly IGestionarEtapaBW gestionarEtapaBW;

        public EtapaController(IGestionarEtapaBW gestionarEtapaBW)
        {
            this.gestionarEtapaBW = gestionarEtapaBW;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<EtapaDTO>>> obtenerEtapas()
        {
            return Ok(EtapaDTOMapper.ConvertirListaDeEtapasADTO(await gestionarEtapaBW.ObtenerEtapas()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EtapaDTO>> obtenerEtapaPorId(int id)
        {
            return Ok(EtapaDTOMapper.ConvertirEtapaADTO(await gestionarEtapaBW.ObtenerEtapaPorId(id)));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> crearEtapa( EtapaDTO etapaDTO)
        {
            return Ok(await gestionarEtapaBW.CrearEtapa(EtapaDTOMapper.ConvertirDTOAEtapa(etapaDTO)));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> actualizarEtapa(EtapaDTO etapaDTO)
        {
            return Ok(await gestionarEtapaBW.ActualizarEtapa(EtapaDTOMapper.ConvertirDTOAEtapa(etapaDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> eliminarEtapa(int id)
        {
            return Ok(await gestionarEtapaBW.EliminarEtapa(id));
        }
    }
}
