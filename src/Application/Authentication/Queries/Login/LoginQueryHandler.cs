using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Authentication;
using Replica.Application.Common.Interfaces.Helpers;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Authentication.Queries.Login
{
    public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _cryptoService;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginQueryHandler(
            IUserRepository userRepository,
            IPasswordService cryptoService,
            IJwtTokenService jwtTokenService) =>
            (_userRepository, _cryptoService, _jwtTokenService) =
            (userRepository, cryptoService, jwtTokenService);

        public async Task<ErrorOr<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByEmailAsync(request.Email);

            if (_cryptoService.HashPassword(request.Password) != user.Password)
            {
                throw new Exception("Invalid password.");
            }

            var token = _jwtTokenService.GenerateToken(user);

            return token;
        }
    }
}
