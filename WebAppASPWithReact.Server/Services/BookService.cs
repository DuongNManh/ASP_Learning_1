// File: Services/BookService.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppASPWithReact.Server.Converters;
using WebAppASPWithReact.Server.DTOs.Requests;
using WebAppASPWithReact.Server.DTOs.Responses;
using WebAppASPWithReact.Server.Models;

namespace WebAppASPWithReact.Server.Services
{
    public class BookService : IBookService
    {
        private readonly BookManagementDbContext _context;

        public BookService(BookManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookResponse>> GetBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.BookCategory)
                .ToListAsync();

            return books.Select(BookConverter.ToBookResponse);
        }

        public async Task<BookResponse> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(b => b.BookId == id);

            return book == null ? null : BookConverter.ToBookResponse(book);
        }

        public async Task<BookResponse> CreateBookAsync(BookDTO book)
        {

            if (book.BookCategoryId <= 0)
            {
                throw new ArgumentException("Invalid book category id", nameof(book.BookCategoryId));
            }

            var newBook = new Book
            {
                BookName = book.BookName,
                Description = book.Description,
                PublicationDate = book.PublicationDate,
                Quantity = book.Quantity,
                Price = book.Price,
                Author = book.Author,
                BookCategoryId = book.BookCategoryId,
                BookCategory = await _context.BookCategories.FindAsync(book.BookCategoryId)
            };

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return BookConverter.ToBookResponse(newBook);
        }

        public async Task<BookResponse> UpdateBookAsync(int id, BookDTO book)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook == null)
            {
                throw new ArgumentException("Book not found", nameof(id));
            }

            if (book.BookCategoryId <= 0)
            {
                throw new ArgumentException("Invalid book category id", nameof(book.BookCategoryId));
            }

            existingBook.BookName = book.BookName;
            existingBook.Description = book.Description;
            existingBook.PublicationDate = book.PublicationDate;
            existingBook.Quantity = book.Quantity;
            existingBook.Price = book.Price;
            existingBook.Author = book.Author;
            existingBook.BookCategoryId = book.BookCategoryId;
            existingBook.BookCategory = await _context.BookCategories.FindAsync(book.BookCategoryId);

            await _context.SaveChangesAsync();

            return BookConverter.ToBookResponse(existingBook);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                throw new ArgumentException("Book not found", nameof(id));
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
