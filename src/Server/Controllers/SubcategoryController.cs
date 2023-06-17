using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class SubcategoryController : ApiController
    {
        public SubcategoryController(IMediator mediator)
            : base(mediator) { }
    }
}
