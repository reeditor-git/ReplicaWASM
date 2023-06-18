using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand, ErrorOr<Category>>
    {
        protected readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) =>
            _categoryRepository = categoryRepository;

        public async Task<ErrorOr<Category>> Handle(DeleteCategoryCommand request, 
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id);

            if (category is null)
                return Errors.Category.NotFound;

            await _categoryRepository.DeleteAsync(request.Id);

            return category;
        }
    }
}
