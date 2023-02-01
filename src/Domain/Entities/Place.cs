namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class Place : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int SeatingCapacity { get; set; }

        public decimal RentPrice { get; set; }

        public bool Available { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Tag>? Tags { get; set; }
    }
}
