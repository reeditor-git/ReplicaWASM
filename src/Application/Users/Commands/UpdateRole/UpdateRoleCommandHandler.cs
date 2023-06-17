using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Users.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler
        : IRequestHandler<UpdateRoleCommand, ErrorOr<bool>>
    {
        protected readonly IUserRepository _userRepository;
        protected readonly IRoleRepository _roleRepository;

        public UpdateRoleCommandHandler(
            IUserRepository userRepository,
            IRoleRepository roleRepository) =>
            (_userRepository, _roleRepository) =
            (userRepository, roleRepository);

        public async Task<ErrorOr<bool>> Handle(UpdateRoleCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);

            if (user is null)
                return Errors.User.NotFound;

            var role = await _roleRepository.GetAsync(request.UserId);

            if(role is null)
                return Errors.Role.NotFound;

            user.Role = role;

            return await _userRepository.UpdateAsync(user);
        }
    }
}
