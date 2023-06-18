using ErrorOr;
using MediatR;

namespace Replica.Application.Orders.Commands.ChangeStatus
{
    public class ChangeStatusCommand 
        : IRequest<ErrorOr<bool>>
    {
        public Guid Id { get; set; }

        public Guid ConfirmationStatusId { get; set; }
    }
}
