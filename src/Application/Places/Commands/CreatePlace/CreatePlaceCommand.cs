using MediatR;

namespace Replica.Application.Places.Commands.CreatePlace
{
    public class CreatePlaceCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int SeatingCapacity { get; set; }

        public decimal RentPrice { get; set; }

        public virtual IEnumerable<Guid> TagsId { get; set; }
    }
}
