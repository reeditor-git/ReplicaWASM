using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime Birthday { get; set; }

        public string? Password { get; set; }

        public Guid RoleId { get; set; }
        public Role? Role { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime ExpiryDate { get; set; }

        public bool Blocked { get; set; }
        public string? BlockingReason { get; set; }
    }
}
