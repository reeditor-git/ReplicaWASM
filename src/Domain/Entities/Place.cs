using Replica.Domain.Common;
using Replica.Domain.Enums;

namespace Replica.Domain.Entities
{
    public class Place : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int SeatingCapacity { get; set; }

        public decimal RentPrice { get; set; }

        public PlaceAvailable Available { get; set; }

        public virtual ICollection<PlaceTag>? PlaceTags { get; set; }
    }
}
