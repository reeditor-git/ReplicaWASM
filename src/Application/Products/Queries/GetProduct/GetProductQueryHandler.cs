using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler
        : IRequestHandler<GetProductQuery, ErrorOr<Product>>
    {
        protected readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;

        public async Task<ErrorOr<Product>> Handle(GetProductQuery request, 
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);

            if (product is null)
                return Errors.Product.NotFound;

            return product;
        }
    }
}
