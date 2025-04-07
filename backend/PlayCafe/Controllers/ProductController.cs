using Microsoft.AspNetCore.Mvc;
using PlayCafe.Services.Interfaces;
using PlayCafe.ViewModels.Cafe;
using PlayCafe.ViewModels.DTO;
using Microsoft.AspNetCore.Authorization;

namespace PlayCafe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("subcategory/{subCategoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetBySubCategoryId(int subCategoryId)
        {
            var products = await _productService.GetProductsBySubCategoryId(subCategoryId);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] ProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                IsAvailable = productDto.IsAvailable,
                SubCategoryId = productDto.SubCategoryId,
                CreatedAt = DateTime.UtcNow
            };

            var id = await _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest();


            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                IsAvailable = productDto.IsAvailable,
                SubCategoryId = productDto.SubCategoryId,
                CreatedAt = DateTime.UtcNow
            };

            var success = await _productService.UpdateProduct(product);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.DeleteProduct(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}/availability")]
        public async Task<IActionResult> UpdateAvailability(int id, [FromBody] bool isAvailable)
        {
            var success = await _productService.UpdateProductAvailability(id, isAvailable);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
} 