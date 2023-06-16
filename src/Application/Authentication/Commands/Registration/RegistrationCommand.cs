using ErrorOr;
using MediatR;

namespace Replica.Application.Authentication.Command.Registration
{
    public sealed class RegistrationCommand : IRequest<ErrorOr<string>>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
        
        public string? Password { get; set; }
    }
}