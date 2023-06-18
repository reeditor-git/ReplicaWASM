using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class PlacesController : ApiController
    {
        public PlacesController(IMediator mediator)
            : base(mediator) { }


    }
}
