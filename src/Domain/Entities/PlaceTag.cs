namespace Replica.Domain.Entities
{
    public class PlaceTag
    {
        public Guid PlaceId { get; set; }
        public Place? Place { get; set; }

        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
