using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Subcategory : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}