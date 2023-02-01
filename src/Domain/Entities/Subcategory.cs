namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class Subcategory : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}