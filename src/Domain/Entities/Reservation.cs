namespace Replica.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public Place Place { get; set; }

        public DateTime ReservationTime { get; set; }
    }
}
