using MediatR;
using System.Text.Json.Serialization;

namespace Replica.Application.Authentication.Command.Registration
{
    public sealed class RegistrationCommand : IRequest<RegistrationViewModel>
    {
        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime Birthday { get; set; }
        
        public string? Password { get; set; }

        [JsonIgnore]
        public string? ApiKey { get; set; }
    }
}