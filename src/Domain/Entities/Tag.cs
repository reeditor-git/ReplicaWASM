using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<ProductTag>? ProductTags { get; set; }
        public ICollection<PlaceTag>? PlaceTags { get; set; }
    }
}