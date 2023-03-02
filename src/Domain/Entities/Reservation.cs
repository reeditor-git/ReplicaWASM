using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public Guid PlaceId { get; set; }
        public Place? Place { get; set; }

        public DateTime ReservationTime { get; set; }
    }
}
