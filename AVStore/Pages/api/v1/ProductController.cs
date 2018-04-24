using AVStore.Web.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AVStore.WebApp.Pages.api.v1
{
    [Produces("application/json")]
    [Route("api/v1/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get(bool excludeOutOfStock = false)
        {
            return Ok(productService.GetProducts(excludeOutOfStock));
        }

        [HttpGet]
        [Route("{productId:int}")]
        public IActionResult GetById(int productId)
        {
            return Ok(productService.GetProduct(productId));
        }

        [HttpGet]
        [Route("{productId:int}/Details")]
        public IActionResult GetProductDetails(int productId)
        {
            return Ok(productService.GetProductDetails(productId));
        }
    }
}