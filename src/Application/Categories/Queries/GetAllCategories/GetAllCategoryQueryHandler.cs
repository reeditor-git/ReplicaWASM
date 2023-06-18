using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler
        : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
    {
        protected readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository) =>
            _categoryRepository = categoryRepository;

        public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, 
            CancellationToken cancellationToken) => 
            await _categoryRepository.GetAllAsync();
    }
}
