using Replica.Domain.Enum;

namespace Replica.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public double Size { get; set; }
        public MeasurementUnits MeasurementUnits { get; set; }

        public decimal Price { get; set; }

        public Guid SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }

        public ICollection<Tag>? Tags { get; set; }
    }
}
