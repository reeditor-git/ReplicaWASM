using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Authentication;
using Replica.Application.Common.Interfaces.Helpers;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Authentication.Command.Registration
{
    public sealed class RegistrationCommandHandler 
        : IRequestHandler<RegistrationCommand, ErrorOr<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _cryptoPassword;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRoleRepository _roleRepository;

        public RegistrationCommandHandler(
            IUserRepository userRepository,
            IPasswordService cryptoPassword,
            IJwtTokenService jwtTokenService,
            IRoleRepository roleRepository) =>
            (_userRepository, _cryptoPassword, _jwtTokenService, _roleRepository) = 
            (userRepository, cryptoPassword, jwtTokenService, roleRepository);

        public async Task<ErrorOr<string>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByEmailAsync(request.Email.ToLower());

            if (user is not null)
                return Errors.Authentication.DuplicateEmail;

            var userRoles = await _roleRepository.GetAllAsync();

            user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = _cryptoPassword.HashPassword(request.Password),
                Role = userRoles.First(x => x.Name == "user")
            };

            await _userRepository.CreateAsync(user);

            var token = _jwtTokenService.GenerateToken(user);

            return token;
        }
    }
}
