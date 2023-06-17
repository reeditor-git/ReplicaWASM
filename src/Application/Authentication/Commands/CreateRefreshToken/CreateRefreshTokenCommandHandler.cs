using ErrorOr;
using MediatR;
using Replica.Domain.AppError;
using Replica.Application.Common.Interfaces.Authentication;
using Replica.Application.Common.Interfaces.Helpers;
using Replica.Application.Common.Interfaces.Repositories;

namespace Replica.Application.Authentication.Commands.CreateRefreshToken
{
    public class CreateRefreshTokenCommandHandler 
        : IRequestHandler<CreateRefreshTokenCommand, ErrorOr<CreateRefreshTokenResult>>
    {
        private readonly ICryptoService _cryptoService;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public CreateRefreshTokenCommandHandler(
            ICryptoService cryptoService,
            IUserRepository userRepository,
            IJwtTokenService jwtTokenService) => 
            (_cryptoService, _userRepository, _jwtTokenService) = 
            (cryptoService, userRepository, jwtTokenService);

        public async Task<ErrorOr<CreateRefreshTokenResult>> Handle(CreateRefreshTokenCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user is null)
                return Errors.User.NotFound;

            var tokenPlain = _jwtTokenService.GenerateRefreshToken();

            user.RefreshToken = tokenPlain;
            user.ExpiryDate = DateTime.UtcNow.AddMinutes(_jwtTokenService.RefreshTokenExpiriesTime);

            await _userRepository.UpdateAsync(user);

            return new CreateRefreshTokenResult 
            { 
                RefreshToken = _cryptoService.Encrypt(tokenPlain, user.Id.ToString()), 
                ExpiryDate = user.ExpiryDate
            };
        }
    }
}
