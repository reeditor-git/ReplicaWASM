using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Application.Common.Interfaces.Services;
using Replica.Domain.Entities;

namespace Replica.Application.Authentication.Command.Registration
{
    public sealed class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtTokenService _jwtTokenService;

        public RegistrationCommandHandler(
            IUserRepository userRepository, 
            IPasswordService passwordService,
            IJwtTokenService jwtTokenService) =>
            (_userRepository, _passwordService, _jwtTokenService) = 
            (userRepository, passwordService, jwtTokenService);

        public async Task<RegistrationViewModel> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            User user = new();

            if (request.Username is not null)
            {
                user = await _userRepository.GetUserByUsernameAsync(request.Username);
            }

            if (user is not null)
            {
                throw new Exception("User with this username already exists.");
            }

            user = new()
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                Birthday = request.Birthday,
            };

            if(request.Password is not null)
            {
                user.Password = _passwordService.HashPassword(request.Password);
            }

            await _userRepository.AddAsync(user);

            var token = _jwtTokenService.GenerateToken(user, request.ApiKey);

            return new RegistrationViewModel 
            {
                JwtSecurityToken = token,
            };
        }
    }
}
