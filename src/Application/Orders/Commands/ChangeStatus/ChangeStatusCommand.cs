using ErrorOr;
using MediatR;
using Replica.Domain.Enums;

namespace Replica.Application.Orders.Commands.ChangeStatus
{
    public class ChangeStatusCommand : IRequest<ErrorOr<bool>>
    {
        public Guid Id { get; set; }

        public ConfirmationStatus ConfirmationStatus { get; set; }
    }
}
