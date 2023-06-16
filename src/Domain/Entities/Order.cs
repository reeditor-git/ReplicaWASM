using Replica.Domain.Common;
using Replica.Domain.Enums;

namespace Replica.Domain.Entities
{
    public class Order : BaseEntity
    {
        public virtual ICollection<Product>? Products { get; set; }
        public virtual Reservation? Reservation { get; set; }

        public string? Comment { get; set; }
        public decimal TotalCost { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public ConfirmationStatus ConfirmationStatus { get; set; }

        public virtual User? User { get; set; }
    }
}
