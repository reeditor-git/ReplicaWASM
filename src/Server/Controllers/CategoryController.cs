using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ApiController
    {
        public CategoryController(IMediator mediator)
            : base(mediator) { }


    }
}
