using eCommerece.Application.Interfaces;
using eCommerece.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerece.Infrastructure.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationOptions _jwt;
        public AuthenticationService(IOptions<AuthenticationOptions> jwt)
        {
            _jwt = jwt.Value;
        }
        public string GenerateToken(Guid userId, string email, string PersonName)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
              new Claim(ClaimTypes.Email, email),
              new Claim(ClaimTypes.Name, PersonName)
            };
            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.ExpiresInMinutes),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
