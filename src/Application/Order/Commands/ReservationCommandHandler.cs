using IdentityModel;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Application.Common.Interfaces.Services;
using Replica.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Replica.Application.Order.Commands
{
    public class ReservationCommandHandler : IRequestHandler<ReservationCommand, ReservationViewModel>
    {
        protected readonly IJwtParserService _jwtParserService;
        protected readonly IUserRepository _userRepository;
        public ReservationCommandHandler(
            IJwtParserService jwtParserService, 
            IUserRepository userRepository) =>
            (_jwtParserService, _userRepository) = 
            (jwtParserService, userRepository);
        public async Task<ReservationViewModel> Handle(ReservationCommand request, CancellationToken cancellationToken)
        {
            var claims = _jwtParserService.JwtParseClaim(request.JwtSecurityToken);

            Guid userId = Guid.Parse(claims.First(claim => claim.Type == JwtClaimTypes.Id).Value);

            User user = await _userRepository.GetUserAsync(userId);



            //return new ReservationViewModel
            //{

            //};

            throw new ValidationException();
        }
    }
}
