namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}