namespace Replica.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
        public ICollection<Place>? Places { get; set; }
    }
}