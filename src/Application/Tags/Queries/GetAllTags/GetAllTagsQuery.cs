using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Tags.Queries.GetAllTags
{
    public class GetAllTagsQuery : IRequest<IEnumerable<Tag>> { }
}
