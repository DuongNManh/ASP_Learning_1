using Microsoft.EntityFrameworkCore;
using WebAppASPWithReact.Server.Converters;
using WebAppASPWithReact.Server.DTOs.Requests;
using WebAppASPWithReact.Server.DTOs.Responses;
using WebAppASPWithReact.Server.Models;

namespace WebAppASPWithReact.Server.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly BookManagementDbContext _context;

        public BookCategoryService(BookManagementDbContext context)
        {
            _context = context;
        }

        public async Task<BookCategoryResponse> CreateBookCategoryAsync(BookCategoryDTO bookCategory)
        {
            // Create a new book category
            var newBookCategory = new BookCategory
            {
                BookGenreType = bookCategory.BookGenreType,
                Description = bookCategory.Description,
                Books = new List<Book>()
            };

            // Add the new book category to the database
            _context.BookCategories.Add(newBookCategory);
            await _context.SaveChangesAsync();
            return  BookCategoryConverter.ToBookCategoryResponse(newBookCategory);
        }

        public async Task<bool> DeleteBookCategoryAsync(int id)
        {
            var existBookCategory = await _context.BookCategories.FindAsync(id);
            if (existBookCategory == null)
            {
                throw new ArgumentException("Book category not found", nameof(id));
            }
            
            // Remove the book category
            _context.BookCategories.Remove(existBookCategory);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<BookCategoryResponse>> GetBookCategoriesAsync()
        {
            // Get all book categories
            var bookCategories = await _context.BookCategories.ToListAsync();
            return bookCategories.Select(BookCategoryConverter.ToBookCategoryResponse);
        }

        public async Task<BookCategoryResponse> GetBookCategoryByIdAsync(int id)
        {
            // Get the book category by id
            var bookCategory = await _context.BookCategories.FindAsync(id);
            return bookCategory == null ? null : BookCategoryConverter.ToBookCategoryResponse(bookCategory);
        }

        public async Task<BookCategoryResponse> UpdateBookCategoryAsync(int id, BookCategoryDTO book)
        {
            // Get the existing book category
            var existingBookCategory = await _context.BookCategories.FindAsync(id);
            if (existingBookCategory == null)
            {
                throw new ArgumentException("Book category not found", nameof(id));
            }
            // Update the book category
            existingBookCategory.BookGenreType = book.BookGenreType;
            existingBookCategory.Description = book.Description;
            await _context.SaveChangesAsync();
            return BookCategoryConverter.ToBookCategoryResponse(existingBookCategory);
        }
    }
}
