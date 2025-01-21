using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Card.Application.Contracts;

namespace Card.Application.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IConfiguration _config;

        public AuthenticationServices(IConfiguration config)
        {
            _config = config;
        }
        public string Login(string usuario, string senha)
        {
            var validLogin = _config["Auth:Login"];
            var validPassword = _config["Auth:Password"];

            if (usuario == validLogin && senha == validPassword)
            {
                var token = GenerateToken(usuario);
                return token ;
            }

            return string.Empty;
        }

        private string GenerateToken(string username)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddMinutes(30),
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
