using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Tags.Commands.CreateTag;
using Replica.Application.Tags.Commands.DeleteTag;
using Replica.Application.Tags.Commands.UpdateTag;
using Replica.Application.Tags.Queries.GetAllTags;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : ApiController
    {
        public TagsController(IMediator mediator) 
            : base(mediator) { }

        [HttpPost("create")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create([FromBody] CreateTagCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete([FromBody] DeleteTagCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpGet("get_all")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> GetAll([FromBody] GetAllTagsQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPatch("update")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Update([FromBody] UpdateTagCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }
    }
}
