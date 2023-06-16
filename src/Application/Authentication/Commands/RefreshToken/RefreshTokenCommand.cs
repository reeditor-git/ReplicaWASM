using ErrorOr;
using MediatR;

namespace Replica.Application.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<ErrorOr<string>>
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
