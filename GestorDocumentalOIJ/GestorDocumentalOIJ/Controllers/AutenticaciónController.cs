using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize]
        public IActionResult IsActive()
        {
            return Ok("Usuario activo");
        }

        // Método privado para generar el token JWT
        private string GenerateJwtToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.Correo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpiresInMinutes"])),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
