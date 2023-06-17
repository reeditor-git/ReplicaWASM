using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;

namespace Replica.Application.Users.Commands.Block
{
    public class BlockUserCommandHandler 
        : IRequestHandler<BlockUserCommand, ErrorOr<BlockUserResult>>
    {
        protected readonly IUserRepository _userRepository;

        public BlockUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<ErrorOr<BlockUserResult>> Handle(BlockUserCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);

            if (user is null)
                return Errors.User.NotFound;

            user.Blocked = true;
            user.BlockingReason = request.BlockingReason;

            await _userRepository.UpdateAsync(user);

            return new BlockUserResult
            { 
                Fullname = $"{user.LastName} {user.FirstName}",
                Block = user.Blocked,
                BlockingReason = user.BlockingReason
            };
        }
    }
}
