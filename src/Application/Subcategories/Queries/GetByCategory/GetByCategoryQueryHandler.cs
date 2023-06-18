using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Subcategories.Queries.GetByCategory
{
    public class GetByCategoryQueryHandler
        : IRequestHandler<GetByCategoryQuery, ErrorOr<IEnumerable<Subcategory>>>
    {
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly ISubcategoryRepository _subcategoryRepository;

        public GetByCategoryQueryHandler(
            ICategoryRepository categoryRepository,
            ISubcategoryRepository subcategoryRepository) =>
            (_categoryRepository, _subcategoryRepository) =
            (categoryRepository, subcategoryRepository);

        public async Task<ErrorOr<IEnumerable<Subcategory>>> Handle(GetByCategoryQuery request, 
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id);

            if (category is null)
                return Errors.Category.NotFound;

            var subcategories = await _subcategoryRepository.GetAllAsync();
            subcategories = subcategories.Where(x => x.Category.Name == category.Name);

            return subcategories.ToList();
        }
    }
}
