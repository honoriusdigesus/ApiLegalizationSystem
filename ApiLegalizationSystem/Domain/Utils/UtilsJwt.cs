using ApiLegalizationSystem.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiLegalizationSystem.Domain.Utils
{
    public class UtilsJwt
    {
        private readonly IConfiguration _configuration;

        public UtilsJwt(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Generated JWT
        public string generateJwt(UserResponseDomain user)
        {
            // 1. Configuración de los claims del usuario
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Role, user.Role)
        };

            // 2. Generación de la clave de seguridad y las credenciales de firma
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Configuración del token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            // 4. Retornar el token generado
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
