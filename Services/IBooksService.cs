using BooksApi.Models;

namespace BooksApi.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetBooksAsync();

        Task<Book?> GetBookAsync(int id);

        Task<Book> CreateBookAsync(Book book);

        Task<bool> UpdateBookAsync(int id, Book updatedBook);

        Task<bool> DeleteBookAsync(int id);
    }
}
