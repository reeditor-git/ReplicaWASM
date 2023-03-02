using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}