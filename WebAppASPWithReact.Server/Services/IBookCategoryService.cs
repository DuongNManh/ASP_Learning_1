using WebAppASPWithReact.Server.DTOs.Requests;
using WebAppASPWithReact.Server.DTOs.Responses;

namespace WebAppASPWithReact.Server.Services
{
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategoryResponse>> GetBookCategoriesAsync();
        Task<BookCategoryResponse> GetBookCategoryByIdAsync(int id);
        Task<BookCategoryResponse> CreateBookCategoryAsync(BookCategoryDTO book);
        Task<BookCategoryResponse> UpdateBookCategoryAsync(int id, BookCategoryDTO book);
        Task<bool> DeleteBookCategoryAsync(int id);
    }
}
