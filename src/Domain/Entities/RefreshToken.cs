namespace Replica.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string RefToken { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}