using ErrorOr;
using MediatR;

namespace Replica.Application.Users.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<ErrorOr<bool>>
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}
