using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : ApiController
    {
        public OrderController(IMediator mediator) 
            : base(mediator) { }
    }
}
