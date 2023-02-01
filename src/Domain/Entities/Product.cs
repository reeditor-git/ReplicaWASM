namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public Subcategory Subcategory { get; set; }

        public ICollection<Tag>? Tags { get; set; }
    }
}
