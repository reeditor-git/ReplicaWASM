using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class PlaceController : ApiController
    {
        public PlaceController(IMediator mediator)
            : base(mediator) { }


    }
}
