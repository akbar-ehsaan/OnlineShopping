using Inventory.Application.Products.Commands;
using Inventory.Application.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inventory.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("Get")]
        public async Task<ActionResult<GetProductsQueryResponse>> Get(GetProductsQuery Query)
        {
            return await Mediator.Send(Query);
        }
    }
}
