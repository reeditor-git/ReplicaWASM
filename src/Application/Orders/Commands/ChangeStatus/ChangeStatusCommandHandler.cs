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
        protected readonly IConfirmationStatusRepository _confirmationStatusRepository;

        public ChangeStatusCommandHandler(
            IOrderRepository orderRepository,
            IConfirmationStatusRepository confirmationStatusRepository) =>
            (_orderRepository, _confirmationStatusRepository) = 
            (orderRepository, confirmationStatusRepository);

        public async Task<ErrorOr<bool>> Handle(ChangeStatusCommand request, 
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id);

            if (order is null)
                return Errors.Order.NotFound;

            var confirmationStatus = await _confirmationStatusRepository
                .GetAsync(request.ConfirmationStatusId);

            if (confirmationStatus is null)
                return Errors.ConfirmationStatus.NotFound;

            order.ConfirmationStatus = confirmationStatus;

            return await _orderRepository.UpdateAsync(order);
        }
    }
}
