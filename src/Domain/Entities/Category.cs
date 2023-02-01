namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Subcategory>? Subcategorys { get; set; }

        public ICollection<ProductSize>? ProductSizes { get; set; }
    }
}