using MediatR;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Authentication.Command.Registration;
using System.ComponentModel.DataAnnotations;

namespace Replica.Server.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly string? _apiKey;

        public AuthenticationController(IMediator mediator, IConfiguration config)
            : base(mediator) => _apiKey = config.GetValue<string>("JWT:ApiKey");

        ///// <summary>       
        ///// Login
        ///// </summary>
        ///// <param name="command"></param>
        ///// <response code="200">Returns user token</response>
        ///// <response code="401">Invalid username or password</response>
        ///// <returns></returns>
        //[ProducesResponseType(200)]
        //[ProducesResponseType(401)]
        //[ProducesResponseType(500)]
        //[HttpPost("/login")]
        //public async Task<ActionResult> Login([FromBody] LoginCommand command)
        //{
        //    try
        //    {
        //        command.ApiKey = _apiKey ?? throw new ArgumentNullException(nameof(String));
        //        var response = await _mediator.Send(command);
        //        return Ok(response);
        //    }
        //    catch (ValidationException e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

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
                command.ApiKey = _apiKey ?? throw new ArgumentNullException(nameof(String));
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
