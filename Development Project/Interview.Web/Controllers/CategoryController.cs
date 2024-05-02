using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Core.Models;
using Sparcpoint.SqlServer.Abstractions;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (category == null)
                return BadRequest("Invalid category data");

            int id = await _categoryRepository.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategory), new { id = id }, category);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null || category.InstanceId != id)
                return BadRequest("Category ID mismatch");

            await _categoryRepository.UpdateCategoryAsync(category);
            return NoContent(); 
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
