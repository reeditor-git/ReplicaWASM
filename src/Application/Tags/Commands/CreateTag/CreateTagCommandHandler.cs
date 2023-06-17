using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandler
        : IRequestHandler<CreateTagCommand, ErrorOr<Guid>>
    {
        protected readonly ITagRepository _tagRepository;

        public CreateTagCommandHandler(ITagRepository tagRepository) =>
            _tagRepository = tagRepository;

        public async Task<ErrorOr<Guid>> Handle(CreateTagCommand request, 
            CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.GetByNameAsync(request.Name);

            if (tag is not null)
                return Errors.Tag.AlreadyExists;

            tag.Name = request.Name;

            return await _tagRepository.CreateAsync(tag);
        }
    }
}
