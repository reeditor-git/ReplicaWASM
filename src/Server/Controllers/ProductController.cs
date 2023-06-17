using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ApiController
    {
        public ProductController(IMediator mediator) 
            : base(mediator) { }

    }
}
