using Microsoft.AspNetCore.Identity;

namespace BooksApi.Services
{
    public interface IAuthService
    {
        string GenerateToken(IdentityUser user);
        Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterAsync(string username, string email, string password);
        Task<(bool Succeeded, string? Token)> LoginAsync(string username, string password);
    }
}
