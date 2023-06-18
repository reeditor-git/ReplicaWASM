using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler 
        : IRequestHandler<CreateCategoryCommand, ErrorOr<Guid>>
    {
        protected readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository) =>
            _categoryRepository = categoryRepository;

        public async Task<ErrorOr<Guid>> Handle(CreateCategoryCommand request, 
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByNameAsync(request.Name);

            if (category is not null)
                return Errors.Category.AlreadyExists;

            category.Name = request.Name;
            category.Description = request.Description;

            return await _categoryRepository.CreateAsync(category);
        }
    }
}
