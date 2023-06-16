using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Authentication;
using Replica.Application.Common.Interfaces.Helpers;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Authentication.Command.Registration
{
    public sealed class RegistrationCommandHandler 
        : IRequestHandler<RegistrationCommand, ErrorOr<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _cryptoPassword;
        private readonly IJwtTokenService _jwtTokenService;

        public RegistrationCommandHandler(
            IUserRepository userRepository,
            IPasswordService cryptoPassword,
            IJwtTokenService jwtTokenService) =>
            (_userRepository, _cryptoPassword, _jwtTokenService) = 
            (userRepository, cryptoPassword, jwtTokenService);

        public async Task<ErrorOr<string>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByEmailAsync(request.Email.ToLower());

            if (user is not null)
            {
                throw new Exception("User with this email already exists!");
            }

            user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            if(request.Password is not null)
            {
                user.Password = _cryptoPassword.HashPassword(request.Password);
            }

            await _userRepository.CreateAsync(user);

            var token = _jwtTokenService.GenerateToken(user);

            return token;
        }
    }
}
