using IdentityModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Replica.Application.Common.Interfaces.Services;
using Replica.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Replica.Infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }

        public string GenerateToken(User user, string apiKey)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(apiKey)), 
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                new Claim(JwtClaimTypes.NickName, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var jwtSecyrityToken = new JwtSecurityToken(
                issuer: "Replica",
                audience: "Replica",
                expires: DateTime.UtcNow.AddHours(2),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecyrityToken);
        }
    }
}

