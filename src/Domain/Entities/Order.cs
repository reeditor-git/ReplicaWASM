namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class Order : BaseEntity
    {
        public Guid UserID { get; set; }
        public User User { get; set; }

        public Guid PlaceId { get; set; }
        public Place Place { get; set; }
        public DateTime ReservationTime { get; set; }

        public ICollection<Product>? Products { get; set; }

        public string? Comment { get; set; }

        public decimal TotalCost { get; set; }

        public bool PaymentStatus { get; set; }

        public bool ConfirmationStatus { get; set; }
    }
}
