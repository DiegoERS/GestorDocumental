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
    public class PermisoRolController : ControllerBase
    {

        private readonly IGestionarPermisoRolBW _gestionarPermisoRolBW;

        public PermisoRolController(IGestionarPermisoRolBW gestionarPermisoRolBW)
        {
            _gestionarPermisoRolBW = gestionarPermisoRolBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermisoRolDTO>>> ObtenerPermisosRol()
        {
            return Ok(PermisoRolDTOMapper.ConvertirListaDePermisosRolesADTO(await _gestionarPermisoRolBW.ObtenerPermisosRol()));
        }

        [HttpPost("AsignarPermisoARol")]
        public async Task<ActionResult<bool>> AsignarPermisoARol(PermisoRolDTO permisoRolDTO)
        {
            return Ok(await _gestionarPermisoRolBW.AsignarPermisoARol(PermisoRolDTOMapper.ConvertirDTOAPermisoRol(permisoRolDTO)));
        }

        [HttpPost("RemoverPermisoARol")]
        public async Task<ActionResult<bool>> RemoverPermisoARol(PermisoRolDTO permisoRolDTO)
        {
            return Ok(await _gestionarPermisoRolBW.RemoverPermisoARol(PermisoRolDTOMapper.ConvertirDTOAPermisoRol(permisoRolDTO)));
        }
    }
}
