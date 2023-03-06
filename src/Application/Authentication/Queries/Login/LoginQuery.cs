using MediatR;
using System.Text.Json.Serialization;

namespace Replica.Application.Authentication.Queries.Login
{
    public class LoginQuery : IRequest<LoginViewModel>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        [JsonIgnore]
        public string? ApiKey { get; set; }
    }
}
