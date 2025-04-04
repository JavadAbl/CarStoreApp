using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarStoreApp.Server.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace CarStoreApp.Server.Services
{
    public class JWTService(IConfiguration config) : IJWTService
    {
        public string createToken(string username)
        {
            var jwtSettings = config.GetSection("JWT").Get<JWTSettings>() ?? throw new Exception("Cannot get jwt config");

            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

            var claims = new List<Claim>
            {
             new (ClaimTypes.NameIdentifier,username)
            };

            var signingCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}