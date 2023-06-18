using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Places.Queries.GetAllPlaces
{
    public class GetAllPlacesQuery : IRequest<IEnumerable<Place>> { }
}
