using System.ComponentModel.DataAnnotations;

namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public string Password { get; set; }

        public Guid RoleId { get; set; }

        public Role? Role { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public string ImageUrl { get; set; }
    }
}
