using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Places.Commands.DeletePlace
{
    public class DeletePlaceCommandHandler
        : IRequestHandler<DeletePlaceCommand, ErrorOr<Place>>
    {
        protected readonly IPlaceRepository _placeRepository;

        public DeletePlaceCommandHandler(IPlaceRepository placeRepository) =>
            _placeRepository = placeRepository;

        public async Task<ErrorOr<Place>> Handle(DeletePlaceCommand request, 
            CancellationToken cancellationToken)
        {
            var place = await _placeRepository.GetAsync(request.Id);

            if (place is null)
                return Errors.Place.NotFound;

            await _placeRepository.DeleteAsync(request.Id);

            return place;
        }
    }
}
