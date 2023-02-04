using Replica.Domain.Enum;

namespace Replica.Domain.Entities
{
    public class Order : BaseEntity
    {
        public ICollection<Product>? Products { get; set; }
        public Guid ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        public string? Comment { get; set; }
        public decimal TotalCost { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public ConfirmationStatus ConfirmationStatus { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}
