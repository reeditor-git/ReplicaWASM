using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Queries.GetBySubcategory
{
    public class GetBySubcategoryQuery : IRequest<ErrorOr<IEnumerable<Product>>>
    {
        public Guid Id { get; set; }
    }
}
