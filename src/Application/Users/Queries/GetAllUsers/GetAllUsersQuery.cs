using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>> { }
}
