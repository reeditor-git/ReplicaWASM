using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Places.Commands.DeletePlace
{
    public class DeletePlaceCommand : IRequest<ErrorOr<Place>>
    {
        public Guid Id { get; set; }
    }
}
