using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Places.Commands.CreatePlace
{
    public class CreatePlaceCommandHandler
        : IRequestHandler<CreatePlaceCommand, Guid>
    {
        protected readonly IPlaceRepository _placeRepository;
        protected readonly ITagRepository _tagRepository;

        public CreatePlaceCommandHandler(
            IPlaceRepository placeRepository,
            ITagRepository tagRepository) =>
            (_placeRepository, _tagRepository) =
            (placeRepository, tagRepository);

        public async Task<Guid> Handle(CreatePlaceCommand request, 
            CancellationToken cancellationToken)
        {
            Place place = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                SeatingCapacity = request.SeatingCapacity,
                RentPrice = request.RentPrice,
            };

            if (request.TagsId is not null )
            {
                foreach( var tag in request.TagsId )
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

            return await _placeRepository.CreateAsync(place);
        }
    }
}
