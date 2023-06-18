using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Subcategories.Commands.CreateSubcategory
{
    public class CreateSubcategoryCommandHandler
        : IRequestHandler<CreateSubcategoryCommand, ErrorOr<Guid>>
    {
        protected readonly ISubcategoryRepository _subcategoryRepository;
        protected readonly ICategoryRepository _categoryRepository;

        public CreateSubcategoryCommandHandler(
            ISubcategoryRepository subcategoryRepository,
            ICategoryRepository categoryRepository) =>
            (_subcategoryRepository, _categoryRepository) = 
            (subcategoryRepository, categoryRepository);

        public async Task<ErrorOr<Guid>> Handle(CreateSubcategoryCommand request, 
            CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetByNameAsync(request.Name);

            if (subcategory is not null)
                return Errors.Subcategory.AlreadyExists;

            subcategory.Name = request.Name;
            subcategory.Description = request.Description;

            var category = await _categoryRepository.GetAsync(request.CategoryId);

            if (category is null)
                return Errors.Category.NotFound;

            subcategory.Category = category;

            return await _subcategoryRepository.CreateAsync(subcategory);
        }
    }
}
