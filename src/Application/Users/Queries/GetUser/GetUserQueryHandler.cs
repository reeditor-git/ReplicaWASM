using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler 
        : IRequestHandler<GetUserQuery, ErrorOr<User>>
    {
        protected readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<ErrorOr<User>> Handle(GetUserQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);

            if (user is null)
                return Errors.User.NotFound;

            return user;
        }
    }
}
