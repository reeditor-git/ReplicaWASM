using Replica.Domain.Common;
using Replica.Domain.Enums;

namespace Replica.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public double Size { get; set; }
        public MeasurementUnits MeasurementUnits { get; set; }

        public decimal Price { get; set; }

        public virtual Subcategory? Subcategory { get; set; }

        public virtual ICollection<ProductTag>? ProductTags { get; set; }
    }
}
