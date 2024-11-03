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
    public class UsuarioOficinaController : ControllerBase
    {
        private readonly IGestionarUsuarioOficinaBW _gestionarUsuarioOficinaBW;

        public UsuarioOficinaController(IGestionarUsuarioOficinaBW gestionarUsuarioOficinaBW)
        {
            _gestionarUsuarioOficinaBW = gestionarUsuarioOficinaBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioOficinaDTO>>> ObtenerUsuariosOficinas()
        {
            return Ok(UsuarioOficinaDTOMapper.ConvertirListaDeUsuariosOficinasADTO(await _gestionarUsuarioOficinaBW.ObtenerUsuariosOficinas()));
        }

        [HttpPost("AsignarUsuarioAOficina")]
        public async Task<ActionResult<bool>> AsignarUsuarioAOficina(UsuarioOficinaDTO usuarioOficinaDTO)
        {
            return Ok(await _gestionarUsuarioOficinaBW.AsignarUsuarioAOficina(UsuarioOficinaDTOMapper.ConvertirDTOAUsuarioOficina(usuarioOficinaDTO)));
        }

        [HttpPost("RemoverUsuarioAOficina")]
        public async Task<ActionResult<bool>> RemoverUsuarioAOficina(UsuarioOficinaDTO usuarioOficinaDTO)
        {
            return Ok(await _gestionarUsuarioOficinaBW.RemoverUsuarioAOficina(UsuarioOficinaDTOMapper.ConvertirDTOAUsuarioOficina(usuarioOficinaDTO)));
        }
    }
}
