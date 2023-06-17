using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandHandler
        : IRequestHandler<UpdateTagCommand, ErrorOr<bool>>
    {
        protected readonly ITagRepository _tagRepository;

        public UpdateTagCommandHandler(ITagRepository tagRepository) =>
            _tagRepository = tagRepository;

        public async Task<ErrorOr<bool>> Handle(UpdateTagCommand request, 
            CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.GetByNameAsync(request.Name);

            if (tag is not null)
                return Errors.Tag.AlreadyExists;

            tag = await _tagRepository.GetAsync(request.Id);
            
            if(tag is null)
                return Errors.Tag.NotFound;

            tag.Name = request.Name;

            return await _tagRepository.UpdateAsync(tag);
        }
    }
}
