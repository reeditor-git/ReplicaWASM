using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Subcategories.Queries.GetByCategory
{
    public class GetByCategoryQuery : IRequest<ErrorOr<IEnumerable<Subcategory>>>
    {
        public Guid Id { get; set; }
    }
}
