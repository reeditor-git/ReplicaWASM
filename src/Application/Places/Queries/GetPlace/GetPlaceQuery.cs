using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Places.Queries.GetPlace
{
    public class GetPlaceQuery : IRequest<ErrorOr<Place>>
    {
        public Guid Id { get; set; }
    }
}
