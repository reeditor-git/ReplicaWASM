using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Places.Queries.GetPlace
{
    public class GetPlaceQueryHandler
        : IRequestHandler<GetPlaceQuery, ErrorOr<Place>>
    {
        protected readonly IPlaceRepository _placeRepository;

        public GetPlaceQueryHandler(IPlaceRepository placeRepository) =>
            _placeRepository = placeRepository;

        public async Task<ErrorOr<Place>> Handle(GetPlaceQuery request, 
            CancellationToken cancellationToken)
        {
            var place = await _placeRepository.GetAsync(request.Id);

            if (place is null)
                return Errors.Place.NotFound;

            return place;
        }
    }
}
