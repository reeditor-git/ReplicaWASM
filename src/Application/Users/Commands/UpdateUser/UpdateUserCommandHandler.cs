using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand, ErrorOr<bool>>
    {
        protected readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<ErrorOr<bool>> Handle(UpdateUserCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);

            if (user is null)
                return Errors.User.NotFound;

            user.Username = request.Username;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.ImageUrl = request.ImageUrl;
            user.Phone = request.Phone;
            user.Email = request.Email;
            user.Birthday = request.Birthday;

            return await _userRepository.UpdateAsync(user);
        }
    }
}
