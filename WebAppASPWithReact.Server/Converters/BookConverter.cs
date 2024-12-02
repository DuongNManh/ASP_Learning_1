// File: Converters/BookConverter.cs
using WebAppASPWithReact.Server.DTOs.Responses;
using WebAppASPWithReact.Server.Models;

namespace WebAppASPWithReact.Server.Converters
{
    public static class BookConverter
    {
        public static BookResponse ToBookResponse(Book book)
        {
            return new BookResponse
            {
                BookId = book.BookId,
                BookName = book.BookName,
                Description = book.Description,
                PublicationDate = book.PublicationDate,
                Quantity = book.Quantity,
                Price = book.Price,
                Author = book.Author,
                BookCategoryName = book.BookCategory.BookGenreType // Assuming BookGenreType is the property name
            };
        }
    }
}
