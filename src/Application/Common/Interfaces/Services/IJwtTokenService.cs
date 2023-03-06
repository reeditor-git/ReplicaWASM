using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user, string apiKey);
        string GenerateRefreshToken();
    }
}