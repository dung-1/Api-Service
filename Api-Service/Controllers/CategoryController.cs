using Api_Service.DTOs;
using Api_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CategoryDto categoryDto)
        {
            var createdCategory = await _categoryService.AddAsync(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<CategoryDto>> Update(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();
            var updatedCategory = await _categoryService.UpdateAsync(categoryDto);
            return Ok(updatedCategory);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
