using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Orders.Queries.GetTodayOrders
{
    public class GetTodayOrdersQuery : IRequest<IEnumerable<Order>> { }
}
