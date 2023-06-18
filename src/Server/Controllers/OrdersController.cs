using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ApiController
    {
        public OrdersController(IMediator mediator) 
            : base(mediator) { }
    }
}
