using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ErrorOr<Product>>
    {
        public Guid Id { get; set; }
    }
}
