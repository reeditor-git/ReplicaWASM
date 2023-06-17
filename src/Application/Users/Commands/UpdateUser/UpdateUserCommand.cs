using ErrorOr;
using MediatR;

namespace Replica.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ErrorOr<bool>>
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }
    }
}
