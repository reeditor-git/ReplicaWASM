using System.Security.Claims;

namespace Replica.Application.Common.Interfaces.Services
{
    public interface IJwtParserService
    {
        IEnumerable<Claim> JwtParseClaim(string jwt);
    }
}