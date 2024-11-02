using GestorDocumentalOIJ.BW.CU;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGestionarUsuarioBW _gestionarUsuarioBW;

        public UsuarioController(IGestionarUsuarioBW gestionarUsuarioBW)
        {
            _gestionarUsuarioBW = gestionarUsuarioBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObtenerUsuarios()
        {
            return Ok(UsuarioDTOMapper.ConvertirListaDeUsuariosADTO(await _gestionarUsuarioBW.ObtenerUsuarios()));
        }

        [HttpGet]
        [Route("ObtenerUsuariosPorOficinaID/{oficinaID}")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObtenerUsuariosPorOficinaID(int oficinaID)
        {
            return Ok(UsuarioDTOMapper.ConvertirListaDeUsuariosADTO(await _gestionarUsuarioBW.ObtenerUsuariosPorOficinaID(oficinaID)));
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<UsuarioDTO>> ObtenerUsuarioPorId(int id)
        {
            return Ok(UsuarioDTOMapper.ConvertirUsuarioADTO(await _gestionarUsuarioBW.ObtenerUsuarioPorId(id)));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CrearUsuario(UsuarioDTO usuarioDTO)
        {
            return Ok(await _gestionarUsuarioBW.CrearUsuario(UsuarioDTOMapper.ConvertirDTOAUsuario(usuarioDTO)));
        }

        [HttpPut]

        public async Task<ActionResult<bool>> ActualizarUsuario(UsuarioDTO usuarioDTO)
        {
            return Ok(await _gestionarUsuarioBW.ActualizarUsuario(UsuarioDTOMapper.ConvertirDTOAUsuario(usuarioDTO)));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> EliminarUsuario(int id)
        {
            return Ok(await _gestionarUsuarioBW.EliminarUsuario(id));
        }

        [HttpPost("autenticar")]

        public async Task<ActionResult<bool>> Autenticar(string Correo, string Password)
        {
            return Ok(await _gestionarUsuarioBW.Autenticar(Correo, Password));
        }

    }
}
