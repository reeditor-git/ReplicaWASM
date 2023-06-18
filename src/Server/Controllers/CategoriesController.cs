using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Categories.Commands.CreateCategory;
using Replica.Application.Categories.Commands.DeleteCategory;
using Replica.Application.Categories.Commands.UpdateCategory;
using Replica.Application.Categories.Queries.GetAllCategory;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator)
            : base(mediator) { }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpDelete]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPatch]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromBody] GetAllCategoryQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
