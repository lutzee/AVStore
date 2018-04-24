using System.Threading.Tasks;
using AVStore.DataAccess.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AVStore.WebApp.Pages.api.v2
{
    [Produces("application/json")]
    [Route("api/v2/Product")]
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProducts(bool excludeOutOfStock = false)
        {
            var products = await mediator.Send(new GetProducts.Query
            {
                ExcludeOutOfStock = excludeOutOfStock
            });

            return Ok(products);
        }
    }
}