using WebAppASPWithReact.Server.DTOs.Responses;
using WebAppASPWithReact.Server.Models;

namespace WebAppASPWithReact.Server.Converters
{
    public static class BookCategoryConverter
    {
        public static BookCategoryResponse ToBookCategoryResponse(BookCategory bookCategory)
        {
            return new BookCategoryResponse
            {
                BookCategoryId = bookCategory.BookCategoryId,
                BookGenreType = bookCategory.BookGenreType,
                Description = bookCategory.Description
            };
        }
    }
}
