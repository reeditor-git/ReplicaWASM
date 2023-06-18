using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Orders.Queries.GetByUser
{
    public class GetByUserQuery : IRequest<ErrorOr<IEnumerable<Order>>>
    {
        public Guid Id { get; set; }
    }
}
