using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler
        : IRequestHandler<UpdateCategoryCommand, ErrorOr<bool>>
    {
        protected readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository) =>
            _categoryRepository = categoryRepository;

        public async Task<ErrorOr<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id);

            if (category is null)
                return Errors.Category.NotFound;

            category.Name = request.Name;
            category.Description = request.Description;

            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
