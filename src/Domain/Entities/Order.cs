using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Order : BaseEntity
    {
        public virtual ICollection<ProductCount>? ProductCounts { get; set; }
        public virtual Reservation? Reservation { get; set; }

        public string? Comment { get; set; }
        public decimal TotalCost { get; set; }

        public virtual PaymentStatus PaymentStatus { get; set; }
        public virtual ConfirmationStatus ConfirmationStatus { get; set; }

        public virtual User? User { get; set; }

        public DateTime Created { get; set; }
    }
}
