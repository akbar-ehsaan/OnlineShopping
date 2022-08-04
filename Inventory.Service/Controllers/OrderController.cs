using Inventory.Application.Products.Commands;
using Inventory.Application.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inventory.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }
  
    }
}
