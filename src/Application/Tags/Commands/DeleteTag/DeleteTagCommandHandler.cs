using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler
        : IRequestHandler<DeleteTagCommand, ErrorOr<Tag>>
    {
        protected readonly ITagRepository _tagRepository;

        public DeleteTagCommandHandler(ITagRepository tagRepository) =>
            _tagRepository = tagRepository;

        public async Task<ErrorOr<Tag>> Handle(DeleteTagCommand request, 
            CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.GetAsync(request.Id);

            if (tag is null)
                return Errors.Tag.NotFound;

            await _tagRepository.DeleteAsync(request.Id);

            return tag;
        }
    }
}
