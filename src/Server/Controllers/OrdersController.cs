using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Orders.Commands.ChangeStatus;
using Replica.Application.Orders.Commands.CreateOrder;
using Replica.Application.Orders.Queries.GetByUser;
using Replica.Application.Orders.Queries.GetTodayOrders;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ApiController
    {
        public OrdersController(IMediator mediator)
            : base(mediator) { }

        [HttpPatch("change-status")]
        [Authorize(Roles = "admin, manager, staff")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        //[HttpPatch]
        //[Authorize(Roles = "admin, manager")]
        //public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
        //{
        //    var response = await _mediator.Send(command);

        //    return response.Match(
        //        response => Ok(response),
        //        errors => Problem(errors));
        //}

        [HttpGet("user/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUser(Guid id)
        {
            var response = await _mediator.Send(new GetByUserQuery
            {
                Id = id
            });

            return Ok(response);
        }

        [HttpGet("today")]
        [AllowAnonymous]
        public async Task<IActionResult> GetToday()
        {
            var response = await _mediator.Send(new GetTodayOrdersQuery());

            return Ok(response);
        }
    }
}
