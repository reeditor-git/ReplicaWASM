using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;

namespace Replica.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler 
        : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        protected readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
