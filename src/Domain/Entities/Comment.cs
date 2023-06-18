using Replica.Domain.Common;

namespace Replica.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public virtual User User { get; set; }

        public virtual Product Product { get; set; }

        public string CommentText { get; set; }

        public int Rating { get; set; }
    }
}
