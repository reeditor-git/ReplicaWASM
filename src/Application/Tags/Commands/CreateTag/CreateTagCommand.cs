using ErrorOr;
using MediatR;

namespace Replica.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand : IRequest<ErrorOr<Guid>>
    {
        public string Name { get; set; }
    }
}
