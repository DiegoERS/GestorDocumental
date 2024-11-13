using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticaciónController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGestionarUsuarioBW _userService;


        public AutenticaciónController(IConfiguration configuration, IGestionarUsuarioBW userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        // Endpoint para registrar
        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(UsuarioDTO model)
        {
            return Ok(await _userService.CrearUsuario(UsuarioDTOMapper.ConvertirDTOAUsuario(model)));
        }

        // Endpoint para loguear
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login(string Correo, string Password)
        {
           return Ok(UsuarioDTOMapper.ConvertirUsuarioADTO(await _userService.Autenticar(Correo, Password)));
        }
    }
}
