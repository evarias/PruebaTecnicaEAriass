using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;

namespace PL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario : ControllerBase
    {
        private readonly BL.Usuario _usuario;

        public Usuario(BL.Usuario usuario)
        {
            _usuario = usuario;
        }

        [HttpPost]
        [Route("GetUser")]
        public IActionResult GetUser(EL.Usuario usuario)
        { 
            EL.Result result = _usuario.GetUser(usuario);
            if (result.Correct)
            {
                var token = GenerateJwtToken((EL.Usuario)result.Object);
                return Ok(token);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
            }
        }

        private string GenerateJwtToken(EL.Usuario usuario)
        {
            
            var claims = new[]
            {
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString())

        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
