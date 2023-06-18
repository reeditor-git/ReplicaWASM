using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }
}
