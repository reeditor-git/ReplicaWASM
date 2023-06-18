using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Places.Queries.GetAllPlaces
{
    public class GetAllPlacesQueryHandler
        : IRequestHandler<GetAllPlacesQuery, IEnumerable<Place>>
    {
        protected readonly IPlaceRepository _placeRepository;

        public GetAllPlacesQueryHandler(IPlaceRepository placeRepository) =>
            _placeRepository = placeRepository;

        public async Task<IEnumerable<Place>> Handle(GetAllPlacesQuery request,
            CancellationToken cancellationToken) =>
            await _placeRepository.GetAllAsync();
    }
}
