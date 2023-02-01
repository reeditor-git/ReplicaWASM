namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}