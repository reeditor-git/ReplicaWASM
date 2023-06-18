using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class SubcategoriesController : ApiController
    {
        public SubcategoriesController(IMediator mediator)
            : base(mediator) { }
    }
}
