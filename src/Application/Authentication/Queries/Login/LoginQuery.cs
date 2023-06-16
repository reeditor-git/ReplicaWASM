using MediatR;
using System.Text.Json.Serialization;

namespace Replica.Application.Authentication.Queries.Login
{
    public class LoginQuery : IRequest<LoginViewModel>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
