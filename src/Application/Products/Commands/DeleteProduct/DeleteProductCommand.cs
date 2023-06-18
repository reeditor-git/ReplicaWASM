using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ErrorOr<Product>>
    {
        public Guid Id { get; set; }
    }
}
