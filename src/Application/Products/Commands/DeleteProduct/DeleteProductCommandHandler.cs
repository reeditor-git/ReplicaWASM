using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand, ErrorOr<Product>>
    {
        protected readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;

        public async Task<ErrorOr<Product>> Handle(DeleteProductCommand request, 
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);

            if (product is null)
                return Errors.Product.NotFound;

            await _productRepository.DeleteAsync(request.Id);

            return product;
        }
    }
}
