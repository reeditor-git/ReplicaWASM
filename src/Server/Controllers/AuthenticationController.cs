using MediatR;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Authentication.Command.Registration;
using Replica.Application.Authentication.Queries.Login;
using System.ComponentModel.DataAnnotations;

namespace Replica.Server.Controllers
{
    public class AuthenticationController : ApiController
    {
        public AuthenticationController(IMediator mediator, IConfiguration config)
            : base(mediator) { }

        /// <summary>       
        /// Login
        /// </summary>
        /// <param name="query"></param>
        /// <response code="200">Returns user token</response>
        /// <response code="401">Invalid username or password</response>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpPost("/login")]
        public async Task<ActionResult> Login([FromBody] LoginQuery query)
        {
            try
            {
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>       
        /// Registration
        /// </summary>
        /// <param name="command"></param>
        /// <response code="200">Returns user token</response>
        /// <response code="401">Invalid user data</response>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpPost("/registration")]
        public async Task<ActionResult> Registration([FromBody] RegistrationCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
