using MediatR;
using Replica.Application.Common.Interfaces.Authentication;
using Replica.Application.Common.Interfaces.Helpers;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Authentication.Queries.Login
{
    public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, LoginViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoPassword _cryptoService;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginQueryHandler(
            IUserRepository userRepository,
            ICryptoPassword cryptoService,
            IJwtTokenService jwtTokenService) =>
            (_userRepository, _cryptoService, _jwtTokenService) =
            (userRepository, cryptoService, jwtTokenService);

        public async Task<LoginViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByEmailAsync(request.Email);

            if (_cryptoService.HashPassword(request.Password) != user.Password)
            {
                throw new Exception("Invalid password.");
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new LoginViewModel
            {
                JwtSecurityToken = token,
            };
        }
    }
}
