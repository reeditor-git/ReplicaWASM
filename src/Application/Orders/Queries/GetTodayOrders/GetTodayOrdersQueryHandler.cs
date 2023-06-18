using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Orders.Queries.GetTodayOrders
{
    public class GetTodayOrdersQueryHandler
        : IRequestHandler<GetTodayOrdersQuery, IEnumerable<Order>>
    {
        protected readonly IOrderRepository _orderRepository;

        public GetTodayOrdersQueryHandler(IOrderRepository orderRepository) =>
            _orderRepository = orderRepository;

        public async Task<IEnumerable<Order>> Handle(GetTodayOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            orders = orders.Where(x => x.Created == DateTime.UtcNow.Date);

            return orders.ToList();
        }
    }
}
