using MediatR;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Order.Commands;
using System.ComponentModel.DataAnnotations;

namespace Replica.Server.Controllers
{
    public class OrderController : ApiController
    {
        public OrderController(IMediator mediator)
            : base(mediator) { }

        /// <summary>       
        /// Reservation
        /// </summary>
        /// <param name="command"></param>
        /// <response code="200">Returns reservation information</response>
        /// <response code="401">Invalid reservation data</response>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpPost("/reservation")]
        public async Task<ActionResult> Reservation([FromBody] ReservationCommand command)
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
