using ErrorOr;
using MediatR;

namespace Replica.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest<ErrorOr<bool>>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
