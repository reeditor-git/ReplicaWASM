using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Products.Commands.CreateProduct;
using Replica.Application.Products.Commands.DeleteProduct;
using Replica.Application.Products.Commands.UpdateProduct;
using Replica.Application.Products.Queries.GetAllProducts;
using Replica.Application.Products.Queries.GetBySubcategory;
using Replica.Application.Products.Queries.GetProduct;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ApiController
    {
        public ProductsController(IMediator mediator) 
            : base(mediator) { }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPatch]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllProductsQuery());

            return Ok(response);
        }

        [HttpGet("subcategory/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBySubcategory(Guid id)
        {
            var response = await _mediator.Send(new GetBySubcategoryQuery
            {
                Id = id
            });

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _mediator.Send(new GetProductQuery
            {
                Id = id
            });

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }
    }
}
