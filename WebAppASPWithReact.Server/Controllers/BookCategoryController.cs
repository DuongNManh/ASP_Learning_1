using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppASPWithReact.Server.DTOs.Requests;
using WebAppASPWithReact.Server.DTOs.Responses;
using WebAppASPWithReact.Server.Services;

namespace WebAppASPWithReact.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        // GET: api/BookCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategoryResponse>>> GetBookCategories()
        {
            var bookCategories = await _bookCategoryService.GetBookCategoriesAsync();
            return Ok(bookCategories);
        }

        // GET: api/BookCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookCategoryResponse>> GetBookCategory(int id)
        {
            var bookCategory = await _bookCategoryService.GetBookCategoryByIdAsync(id);

            if (bookCategory == null)
            {
                return NotFound();
            }

            return Ok(bookCategory);
        }

        // POST: api/BookCategory
        [HttpPost]
        public async Task<ActionResult<BookCategoryResponse>> CreateBookCategory(BookCategoryDTO bookCategoryDTO)
        {
            var bookCategory = await _bookCategoryService.CreateBookCategoryAsync(bookCategoryDTO);
            return CreatedAtAction(nameof(GetBookCategory), new { id = bookCategory.BookCategoryId }, bookCategory);
        }

        // PUT: api/BookCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookCategory(int id, BookCategoryDTO bookCategoryDTO)
        {
            var result = await _bookCategoryService.UpdateBookCategoryAsync(id, bookCategoryDTO);
            return NoContent();
        }

        // DELETE: api/BookCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCategory(int id)
        {
            var result = await _bookCategoryService.DeleteBookCategoryAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
