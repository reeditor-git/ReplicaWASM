using MediatR;
using System.Text.Json.Serialization;

namespace Replica.Application.Authentication.Command.Registration
{
    public sealed class RegistrationCommand : IRequest<RegistrationViewModel>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
        
        public string? Password { get; set; }
    }
}