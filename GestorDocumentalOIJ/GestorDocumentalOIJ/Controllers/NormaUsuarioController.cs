using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormaUsuarioController : ControllerBase
    {
        private readonly IGestionarNormaUsuarioBW _gestionarNormaUsuarioBW;

        public NormaUsuarioController(IGestionarNormaUsuarioBW gestionarNormaUsuarioBW)
        {
            _gestionarNormaUsuarioBW = gestionarNormaUsuarioBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NormaUsuarioDTO>>> ObtenerNormasUsuarios()
        {
            return Ok(NormaUsuarioDTOMapper.ConvertirListaDeNormasUsuariosADTO(await _gestionarNormaUsuarioBW.ObtenerNormasUsuarios()));
        }

        [HttpPost("AsignarNormaUsuario")]
        public async Task<ActionResult<bool>> AsignarNormaUsuario(NormaUsuarioDTO normaUsuarioDTO)
        {
            return Ok(await _gestionarNormaUsuarioBW.AsignarNormaUsuario(NormaUsuarioDTOMapper.ConvertirDTOANormaUsuario(normaUsuarioDTO)));
        }

        [HttpPost("EliminarNormaUsuario")]

        public async Task<ActionResult<bool>> EliminarNormaUsuario(NormaUsuarioDTO normaUsuarioDTO)
        {
            return Ok(await _gestionarNormaUsuarioBW.EliminarNormaUsuario(NormaUsuarioDTOMapper.ConvertirDTOANormaUsuario(normaUsuarioDTO)));
        }
    }
}
