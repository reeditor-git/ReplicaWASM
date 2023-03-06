using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Application.Common.Interfaces.Services;
using Replica.Domain.Entities;

namespace Replica.Application.Authentication.Queries.Login
{
    public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, LoginViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginQueryHandler(
            IUserRepository userRepository,
            IPasswordService passwordService,
            IJwtTokenService jwtTokenService) =>
            (_userRepository, _passwordService, _jwtTokenService) =
            (userRepository, passwordService, jwtTokenService);

        public async Task<LoginViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            User user = new();

            if (request.Username is not null)
            {
                user = await _userRepository.GetUserByUsernameAsync(request.Username);
            }

            if (_passwordService.HashPassword(request.Password) != user.Password)
            {
                throw new Exception("Invalid password.");
            }

            var token = _jwtTokenService.GenerateToken(user, request.ApiKey);

            return new LoginViewModel
            {
                JwtSecurityToken = token,
            };
        }
    }
}
