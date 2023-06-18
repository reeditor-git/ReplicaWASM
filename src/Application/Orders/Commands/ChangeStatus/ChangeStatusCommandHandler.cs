using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Orders.Commands.ChangeStatus
{
    public class ChangeStatusCommandHandler
        : IRequestHandler<ChangeStatusCommand, ErrorOr<bool>>
    {
        protected readonly IOrderRepository _orderRepository;

        public ChangeStatusCommandHandler(IOrderRepository orderRepository) =>
            _orderRepository = orderRepository;

        public async Task<ErrorOr<bool>> Handle(ChangeStatusCommand request, 
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id);

            if (order is null)
                return Errors.Order.NotFound;

            order.ConfirmationStatus = request.ConfirmationStatus;

            return await _orderRepository.UpdateAsync(order);
        }
    }
}
