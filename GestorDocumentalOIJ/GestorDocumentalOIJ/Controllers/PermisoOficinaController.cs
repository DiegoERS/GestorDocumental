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
    public class PermisoOficinaController : ControllerBase
    {
        private readonly IGestionarPermisoOficinaBW _gestionarPermisoOficinaBW;

        public PermisoOficinaController(IGestionarPermisoOficinaBW gestionarPermisoOficinaBW)
        {
            _gestionarPermisoOficinaBW = gestionarPermisoOficinaBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermisoOficinaDTO>>> ObtenerPermisosOficina()
        {
            return Ok(PermisoOficinaDTOMapper.ConvertirListaDePermisosOficinasADTO(await _gestionarPermisoOficinaBW.ObtenerPermisosOficina()));
        }

        [HttpPost("AsignarPermisoAOficina")]
        public async Task<ActionResult<bool>> AsignarPermisoAOficina(PermisoOficinaDTO permisoOficinaDTO)
        {
            return Ok(await _gestionarPermisoOficinaBW.AsignarPermisoAOficina(PermisoOficinaDTOMapper.ConvertirDTOAPermisoOficina(permisoOficinaDTO)));
        }

        [HttpPost("RemoverPermisoAOficina")]
        public async Task<ActionResult<bool>> RemoverPermisoAOficina(PermisoOficinaDTO permisoOficinaDTO)
        {
            return Ok(await _gestionarPermisoOficinaBW.RemoverPermisoAOficina(PermisoOficinaDTOMapper.ConvertirDTOAPermisoOficina(permisoOficinaDTO)));
        }
    }
}
