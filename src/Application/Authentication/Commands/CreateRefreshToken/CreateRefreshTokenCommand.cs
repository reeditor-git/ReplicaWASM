using ErrorOr;
using MediatR;

namespace Replica.Application.Authentication.Commands.CreateRefreshToken
{
    public class CreateRefreshTokenCommand 
        : IRequest<ErrorOr<CreateRefreshTokenResult>>
    {
        public string Email { get; set; }
    }
}
