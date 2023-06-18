using ErrorOr;
using MediatR;

namespace Replica.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand 
        : IRequest<ErrorOr<Guid>>
    {
        public IEnumerable<KeyValuePair<Guid, int>> Products { get; set; }

        public Guid PlaceId { get; set; }

        public DateTime ReservationTime { get; set; }

        public string? Comment { get; set; }

        public decimal TotalCost { get; set; }

        public Guid PaymentStatusId { get; set; }

        public Guid UserId { get; set; }
    }
}
