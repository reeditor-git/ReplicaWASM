using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<ErrorOr<Tag>>
    {
        public Guid Id { get; set; }
    }
}
