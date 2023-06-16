using MediatR;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Authentication.Command.Registration;
using Replica.Application.Authentication.Commands.RefreshToken;
using Replica.Application.Authentication.Queries.Login;
using System.ComponentModel.DataAnnotations;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ApiController
    {
        public AuthenticationController(IMediator mediator, IConfiguration config)
            : base(mediator) { }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            var response = await _mediator.Send(query);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpPost("register")]
        public async Task<IActionResult> Registration([FromBody] RegistrationCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }
    }
}
