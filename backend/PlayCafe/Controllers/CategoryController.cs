using Microsoft.AspNetCore.Mvc;
using PlayCafe.Services.Interfaces;
using PlayCafe.ViewModels.Cafe;
using PlayCafe.ViewModels.DTO;
using Microsoft.AspNetCore.Authorization;

namespace PlayCafe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CategoryDTO categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            var id = await _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
                return BadRequest();

            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            var success = await _categoryService.UpdateCategory(category);
            if (!success)
                return NotFound();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _categoryService.DeleteCategory(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
} 