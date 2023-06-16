namespace Replica.Domain.Entities
{
    public class PlaceTag
    {
        public Guid? PlaceId { get; set; }
        public virtual Place? Place { get; set; }

        public Guid? TagId { get; set; }
        public virtual Tag? Tag { get; set; }
    }
}
