using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class ProductCount : BaseEntity
    {
        public virtual Product Product { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }
    }
}
