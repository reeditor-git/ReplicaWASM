using Replica.Domain.AppError;
using ErrorOr;
using IdentityModel;
using MediatR;
using Replica.Application.Common.Interfaces.Authentication;
using Replica.Application.Common.Interfaces.Helpers;
using Replica.Application.Common.Interfaces.Repositories;

namespace Replica.Application.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler 
        : IRequestHandler<RefreshTokenCommand, ErrorOr<string>>
    {
        private readonly ICryptoService _cryptoService;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IJwtParser _jwtParser;

        public RefreshTokenCommandHandler(
            ICryptoService cryptoService,
            IUserRepository userRepository, 
            IJwtTokenService jwtTokenService,
            IJwtParser jwtParser) =>
            (_cryptoService, _userRepository, _jwtTokenService, _jwtParser) = 
            (cryptoService, userRepository, jwtTokenService, jwtParser);

        public async Task<ErrorOr<string>> Handle(RefreshTokenCommand request, 
            CancellationToken cancellationToken)
        {
            var claims = _jwtParser.JwtParseClaim(request.AccessToken);

            if (!claims.Any(x => x.Type == JwtClaimTypes.Id))
                return Errors.Authentication.InvalidAccessToken;

            var userId = Guid.Parse(claims.First(x => x.Type == JwtClaimTypes.Id).Value);
            var user = await _userRepository.GetAsync(userId);

            if(user is null)
                return Errors.User.NotFound;

            var tokenPlain = _cryptoService.Decrypt(request.RefreshToken, userId.ToString());

            if(user.ExpiryDate > DateTime.UtcNow || user.RefreshToken == tokenPlain)
                return Errors.Authentication.RefreshTokenExpired;

            return _jwtTokenService.GenerateToken(user);
        }
    }
}
