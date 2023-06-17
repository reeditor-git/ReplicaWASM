using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Tags.Queries.GetAllTags
{
    public class GetAllTagsQueryHandler
        : IRequestHandler<GetAllTagsQuery, IEnumerable<Tag>>
    {
        protected readonly ITagRepository _tagRepository;

        public GetAllTagsQueryHandler(ITagRepository tagRepository) =>
            _tagRepository = tagRepository;

        public async Task<IEnumerable<Tag>> Handle(GetAllTagsQuery request, 
            CancellationToken cancellationToken) =>
            await _tagRepository.GetAllAsync();
    }
}
