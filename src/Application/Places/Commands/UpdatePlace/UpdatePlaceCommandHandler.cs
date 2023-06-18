using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Places.Commands.UpdatePlace
{
    public class UpdatePlaceCommandHandler
        : IRequestHandler<UpdatePlaceCommand, ErrorOr<bool>>
    {
        protected readonly IPlaceRepository _placeRepository;
        protected readonly ITagRepository _tagRepository;

        public UpdatePlaceCommandHandler(
            IPlaceRepository placeRepository,
            ITagRepository tagRepository) =>
            (_placeRepository, _tagRepository) =
            (placeRepository, tagRepository);

        public async Task<ErrorOr<bool>> Handle(UpdatePlaceCommand request, 
            CancellationToken cancellationToken)
        {
            var place = await _placeRepository.GetAsync(request.PlaceId);

            if (place is null)
                return Errors.Place.NotFound;

            place.Name = request.Name;
            place.Description = request.Description;
            place.ImageUrl = request.ImageUrl;
            place.SeatingCapacity = request.SeatingCapacity;
            place.RentPrice = request.RentPrice;

            if (request.TagsId is not null)
            {
                foreach (var tag in request.TagsId)
                {
                    var tagValue = await _tagRepository.GetAsync(tag);

                    if (tagValue is not null)
                        place.PlaceTags.Add(new PlaceTag 
                        {
                            PlaceId = place.Id,
                            TagId = tagValue.Id,
                        });
                }
            }

            return await _placeRepository.UpdateAsync(place);
        }
    }
}
