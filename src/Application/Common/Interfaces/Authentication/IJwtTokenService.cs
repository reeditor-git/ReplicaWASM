using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);

        string GenerateRefreshToken();

        int TokenExpiriesTime { get; }

        int RefreshTokenExpiriesTime { get; }
    }
}
