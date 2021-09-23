using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using BISolutions.Models;

namespace BISolutions.DomainService
{
    public class CreateToken
    {
        private readonly IConfiguration _configuration;

        public CreateToken(IConfiguration configuracion)
        {
            this._configuration = configuracion;
        }

        public string CreateJWT(Usuario usuario)
        {
            var secretKey = _configuration["AppSettings:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(secretKey));
            var claims = new Claim[]{
                new Claim(ClaimTypes.Name, usuario.usuario_correo),
                new Claim("rol_descripcion", usuario.Rol.rol_descripcion)
            };

            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature
            );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
