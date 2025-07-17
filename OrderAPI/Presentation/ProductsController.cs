using Microsoft.AspNetCore.Mvc;
using OrderSharedContent;
using Microsoft.AspNetCore.Authorization;
using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;
using OrderAPI.Application.UseCases.ProductUseCase;

namespace OrderAPI.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return Ok(products);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in get all prod: ex.Message");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
