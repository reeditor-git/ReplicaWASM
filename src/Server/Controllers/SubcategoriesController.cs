using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Subcategories.Commands.CreateSubcategory;
using Replica.Application.Subcategories.Commands.DeleteSubcategory;
using Replica.Application.Subcategories.Commands.UpdateSubcategory;
using Replica.Application.Subcategories.Queries.GetByCategory;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class SubcategoriesController : ApiController
    {
        public SubcategoriesController(IMediator mediator)
            : base(mediator) { }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create([FromBody] CreateSubcategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpDelete]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete([FromBody] DeleteSubcategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPatch]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Update([FromBody] UpdateSubcategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpGet("category/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var response = await _mediator.Send(new GetByCategoryQuery
            {
                Id = id
            });

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }
    }
}
