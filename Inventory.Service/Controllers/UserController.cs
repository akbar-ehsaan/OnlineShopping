using Inventory.Application.Products.Commands;
using Inventory.Application.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Inventory.Application.Products.Queries.GetUserQueryHandler;

namespace Inventory.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        [HttpPost("Get")]
        public async Task<ActionResult<GetUserResponse>> Get(GetUserQuery Query)
        {
            return await Mediator.Send(Query);
        }
  
    }
}
