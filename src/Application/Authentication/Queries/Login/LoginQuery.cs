using ErrorOr;
using MediatR;

namespace Replica.Application.Authentication.Queries.Login
{
    public class LoginQuery : IRequest<ErrorOr<string>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
