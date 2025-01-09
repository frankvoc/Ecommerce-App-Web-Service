//Could not get a functioning FRONTEND
//For now all SWAGGER endpoints work but integrating to a frontend did not work
using EcommerceBusinessLogic;
using EcommerceModels;
using Microsoft.AspNetCore.Mvc;
namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductDTO productDto)
        {
            await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Name }, productDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductDTO productDto)
        {
            try
            {
                await _productService.UpdateProductAsync(id, productDto);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
