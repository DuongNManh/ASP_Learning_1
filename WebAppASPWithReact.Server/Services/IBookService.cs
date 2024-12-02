// File: Services/IBookService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppASPWithReact.Server.DTOs.Requests;
using WebAppASPWithReact.Server.DTOs.Responses;

namespace WebAppASPWithReact.Server.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetBooksAsync();
        Task<BookResponse> GetBookByIdAsync(int id);
        Task<BookResponse> CreateBookAsync(BookDTO book);
        Task<BookResponse> UpdateBookAsync(int id, BookDTO book);
        Task<bool> DeleteBookAsync(int id);
    }
}
