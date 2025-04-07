using Microsoft.AspNetCore.Mvc;
using PlayCafe.Services.Interfaces;
using PlayCafe.ViewModels.Cafe;
using PlayCafe.ViewModels.DTO;
using Microsoft.AspNetCore.Authorization;

namespace PlayCafe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryDTO>>> GetAll()
        {
            var subCategories = await _subCategoryService.GetAllSubCategories();
            return Ok(subCategories);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<SubCategoryDTO>>> GetByCategoryId(int categoryId)
        {
            var subCategories = await _subCategoryService.GetSubCategoriesByCategoryId(categoryId);
            return Ok(subCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryDTO>> GetById(int id)
        {
            var subCategory = await _subCategoryService.GetSubCategoryById(id);
            if (subCategory == null)
                return NotFound();

            return Ok(subCategory);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] SubCategoryDTO subCategoryDto)
        {
            var subCategory = new SubCategory
            {
                Name = subCategoryDto.Name,
                Description = subCategoryDto.Description,
                CategoryId = subCategoryDto.CategoryId
            };
            var id = await _subCategoryService.CreateSubCategory(subCategory);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubCategoryDTO subCategoryDto)
        {
            if (id != subCategoryDto.Id)
                return BadRequest();

            var subCategory = new SubCategory
            {
                Id = subCategoryDto.Id,
                Name = subCategoryDto.Name,
                Description = subCategoryDto.Description,
                CategoryId = subCategoryDto.CategoryId
            };

            var success = await _subCategoryService.UpdateSubCategory(subCategory);
            if (!success)
                return NotFound();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _subCategoryService.DeleteSubCategory(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
} 