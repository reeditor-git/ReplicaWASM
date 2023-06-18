using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Queries.GetBySubcategory
{
    public class GetBySubcategoryQueryHandler
        : IRequestHandler<GetBySubcategoryQuery, ErrorOr<IEnumerable<Product>>>
    {
        protected readonly ISubcategoryRepository _subcategoryRepository;
        protected readonly IProductRepository _productRepository;

        public GetBySubcategoryQueryHandler(
            ISubcategoryRepository subcategoryRepository,
            IProductRepository productRepository) =>
            (_subcategoryRepository, _productRepository) =
            (subcategoryRepository, productRepository);

        public async Task<ErrorOr<IEnumerable<Product>>> Handle(GetBySubcategoryQuery request, 
            CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetAsync(request.Id);

            if (subcategory is null)
                return Errors.Subcategory.NotFound;

            var products = await _productRepository.GetAllAsync();

            products = products.Where(x => x.Subcategory.Name == subcategory.Name);

            return products.ToList();
        }
    }
}
