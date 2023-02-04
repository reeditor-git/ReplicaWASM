namespace Replica.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        public string Password { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
