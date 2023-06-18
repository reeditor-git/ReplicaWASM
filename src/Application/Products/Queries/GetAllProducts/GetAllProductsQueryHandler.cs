using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler
        : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        protected readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request,
            CancellationToken cancellationToken) =>
            await _productRepository.GetAllAsync();
    }
}
