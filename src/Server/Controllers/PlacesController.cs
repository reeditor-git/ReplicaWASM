using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Orders.Commands.ChangeStatus;
using Replica.Application.Orders.Queries.GetByUser;
using Replica.Application.Places.Commands.CreatePlace;
using Replica.Application.Places.Commands.DeletePlace;
using Replica.Application.Places.Commands.UpdatePlace;
using Replica.Application.Places.Queries.GetAllPlaces;
using Replica.Application.Places.Queries.GetPlace;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class PlacesController : ApiController
    {
        public PlacesController(IMediator mediator)
            : base(mediator) { }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create([FromBody] CreatePlaceCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete([FromBody] DeletePlaceCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPatch]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Update([FromBody] UpdatePlaceCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _mediator.Send(new GetPlaceQuery
            {
                Id = id
            });

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllPlacesQuery());

            return Ok(response);
        }
    }
}
