namespace Replica.Application.Order.Commands
{
    public class ReservationViewModel
    {
        public string? Name { get; set; }
        public int SeatingCapacity { get; set; }
        public decimal RentPrice { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
