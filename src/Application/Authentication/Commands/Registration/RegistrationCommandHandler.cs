using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Authentication.Command.Registration
{
    public sealed class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationViewModel>
    {
        private readonly IUserRepository _repository;

        public RegistrationCommandHandler(IUserRepository repository) =>
            _repository = repository;

        public async Task<RegistrationViewModel> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            User user = new();

            if (request.Username is not null)
            {
                user = await _repository.GetUserByUsernameAsync(request.Username);
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
                user.Password = new PasswordService(request.Password).Hash;
            }

            await _repository.AddAsync(user);

            

            return new RegistrationViewModel 
            {
                Id = user.Id,
            };
        }
    }
}
