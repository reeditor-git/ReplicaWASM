using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Users.Commands.Block;
using Replica.Application.Users.Commands.UpdateUser;
using Replica.Application.Users.Queries.GetAllUsers;
using Replica.Application.Users.Queries.GetUser;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        public UsersController(IMediator mediator)
            : base(mediator) { }

        [HttpPatch("block")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Block([FromBody] BlockUserCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPatch("update_role")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPatch("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetUser([FromBody] GetUserQuery query)
        {
            var response = await _mediator.Send(query);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpGet("get_all")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> GetAllUser([FromBody] GetAllUsersQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
