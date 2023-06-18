using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Orders.Queries.GetByUser
{
    public class GetByUserQueryHandler
        : IRequestHandler<GetByUserQuery, ErrorOr<IEnumerable<Order>>>
    {
        protected readonly IUserRepository _userRepository;
        protected readonly IOrderRepository _orderRepository;

        public GetByUserQueryHandler(
            IUserRepository userRepository,
            IOrderRepository orderRepository) =>
            (_userRepository, _orderRepository) =
            (userRepository, orderRepository);

        public async Task<ErrorOr<IEnumerable<Order>>> Handle(GetByUserQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);

            if (user is null)
                return Errors.User.NotFound;

            var orders = await _orderRepository.GetAllAsync();

            orders = orders.Where(x => x.User.Email == user.Email);

            return orders.ToList();
        }
    }
}
