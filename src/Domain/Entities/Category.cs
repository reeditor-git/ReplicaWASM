using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Font { get; set; }

        public ICollection<Subcategory>? Subcategorys { get; set; }
    }
}