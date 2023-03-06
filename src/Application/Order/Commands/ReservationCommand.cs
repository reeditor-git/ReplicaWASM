using MediatR;

namespace Replica.Application.Order.Commands
{
    public class ReservationCommand : IRequest<ReservationViewModel>
    {
        public string? JwtSecurityToken { get; set; }

        public string? PlaceId { get; set; }

        public DateTime ReservationTime { get; set; }
    }
}
