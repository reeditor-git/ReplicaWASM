using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public virtual Place? Place { get; set; }

        public DateTime ReservationTime { get; set; }
    }
}
