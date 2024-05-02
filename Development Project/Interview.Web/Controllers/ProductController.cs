using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Core.Models;
using Sparcpoint.SqlServer.Abstractions;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
	[Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var productId = await _productRepository.AddProductAsync(product);
            return Ok(new { ProductId = productId });
        }

        [HttpGet("search-products")]
        public async Task<IActionResult> SearchProducts(string metadataKey, string metadataValue)
        {
            var products = await _productRepository.SearchProductsAsync(metadataKey, metadataValue);
            return Ok(products);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            bool updated = await _productRepository.UpdateProductAsync(product);
            return Ok(new { Updated = updated });
        }
    }
}
