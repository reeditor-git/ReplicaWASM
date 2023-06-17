using ErrorOr;
using MediatR;

namespace Replica.Application.Users.Commands.Block
{
    public class BlockUserCommand : IRequest<ErrorOr<BlockUserResult>>
    {
        public Guid Id { get; set; }

        public string BlockingReason { get; set; }
    }
}
