namespace Replica.Domain.Entities
{
#pragma warning disable CS8618
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}