using ErrorOr;
using MediatR;
using Replica.Domain.Enums;

namespace Replica.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<ErrorOr<Guid>>
    {
        public IEnumerable<Guid> ProductIds { get; set; }

        public Guid PlaceId { get; set; }

        public DateTime ReservationTime { get; set; }

        public string? Comment { get; set; }

        public decimal TotalCost { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public Guid UserId { get; set; }
    }
}
