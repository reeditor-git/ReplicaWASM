using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ApiController
    {
        public ProductsController(IMediator mediator) 
            : base(mediator) { }

    }
}
