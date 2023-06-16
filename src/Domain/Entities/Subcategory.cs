using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Subcategory : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}