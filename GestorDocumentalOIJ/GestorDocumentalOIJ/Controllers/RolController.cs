using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IGestionarRolBW _gestionarRolBW;

        public RolController(IGestionarRolBW gestionarRolBW)
        {
            _gestionarRolBW = gestionarRolBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolDTO>>> ObtenerRoles()
        {
            return Ok(RolDTOMapper.ConvertirListaDeRolesADTO(await _gestionarRolBW.ObtenerRoles()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RolDTO>> ObtenerRolPorId(int id)
        {
            return Ok(RolDTOMapper.ConvertirRolADTO(await _gestionarRolBW.ObtenerRolPorId(id)));
        }

        [HttpPost]

        public async Task<ActionResult<bool>> CrearRol(RolDTO rolDTO)
        {
            return Ok(await _gestionarRolBW.CrearRol(RolDTOMapper.ConvertirDTOARol(rolDTO)));
        }

        [HttpPut]

        public async Task<ActionResult<bool>> ActualizarRol(RolDTO rolDTO)
        {
            return Ok(await _gestionarRolBW.ActualizarRol(RolDTOMapper.ConvertirDTOARol(rolDTO)));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> EliminarRol(int id)
        {
            return Ok(await _gestionarRolBW.EliminarRol(id));
        }


    }
}
