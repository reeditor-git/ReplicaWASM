using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<ErrorOr<User>>
    {
        public Guid Id { get; set; }
    }
}
