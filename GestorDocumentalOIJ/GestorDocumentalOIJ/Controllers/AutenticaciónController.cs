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
        private readonly UsuarioSesionHttp _usuarioSesion;


        public AutenticaciónController(IConfiguration configuration, IGestionarUsuarioBW userService, UsuarioSesionHttp usuarioSesionHttp)
        {
            _configuration = configuration;
            _userService = userService;
            _usuarioSesion = usuarioSesionHttp;
        }

        // Endpoint para registrar
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioDTO model)
        {
            var success = await _userService.CrearUsuario(UsuarioDTOMapper.ConvertirDTOAUsuario(model));
            if (!success)
                return BadRequest("Error al registrar el usuario.");

            return Ok("Usuario registrado exitosamente");
        }

        // Endpoint para loguear
        [HttpPost("login")]
        public async Task<IActionResult> Login(string Correo, string Password)
        {
            var user = await _userService.Autenticar(Correo, Password);
            if (user == null)
                return Unauthorized("Credenciales inválidas");

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        // Endpoint para verificar si el usuario está activo
        [HttpGet("isactive")]
        public IActionResult IsActive()
        {
            var usuario = _usuarioSesion.GetUsuarioSesion();

            if (usuario != null)
            {
                return Ok("Usuario activo");
            }
            return BadRequest("Usuario no encontrado");
        }

        // Método privado para generar el token JWT
        private string GenerateJwtToken(Usuario user)
        {
            
            try
            {
                var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Email, user.Correo),
                 new Claim(ClaimTypes.Role, user.RolID.ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = credential
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescription);

                return tokenHandler.WriteToken(token);
            }catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
    }
}
