using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator)
            : base(mediator) { }


    }
}
