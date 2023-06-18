using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Subcategories.Commands.UpdateSubcategory
{
    public class UpdateSubcategoryCommandHandler
        : IRequestHandler<UpdateSubcategoryCommand, ErrorOr<bool>>
    {
        protected readonly ISubcategoryRepository _subcategoryRepository;

        public UpdateSubcategoryCommandHandler(ISubcategoryRepository subcategoryRepository) =>
            _subcategoryRepository = subcategoryRepository;

        public async Task<ErrorOr<bool>> Handle(UpdateSubcategoryCommand request, 
            CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetAsync(request.Id);

            if (subcategory is null)
                return Errors.Subcategory.NotFound;

            subcategory.Name = request.Name;
            subcategory.Description = request.Description;

            return await _subcategoryRepository.UpdateAsync(subcategory);
        }
    }
}
