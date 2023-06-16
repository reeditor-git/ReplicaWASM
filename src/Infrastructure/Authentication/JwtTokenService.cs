using IdentityModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Replica.Application.Common.Interfaces.Authentication;
using Replica.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Replica.Infrastructure.Authentication
{
    public class JwtTokenService : IJwtTokenService
    {
        readonly JwtSettings jwtSettings;

        public JwtTokenService(IOptions<JwtSettings> jwtSettings) => 
            this.jwtSettings = jwtSettings.Value;

        public int TokenExpiriesTime => jwtSettings.TokenExpiryTime;

        public int RefreshTokenExpiriesTime => jwtSettings.RefreshTokenExpiryTime;

        public string GenerateRefreshToken() =>
            Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                new Claim(JwtClaimTypes.Name, user.FirstName),
                new Claim(JwtClaimTypes.FamilyName, user.LastName),
                new Claim(JwtClaimTypes.Role, user.Role.Name)
            };

            var jwtSecyrityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.TokenExpiryTime),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecyrityToken);
        }
    }
}
