using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string? Name { get; set; }

        public virtual ICollection<ProductTag>? ProductTags { get; set; }
        public virtual ICollection<PlaceTag>? PlaceTags { get; set; }
    }
}