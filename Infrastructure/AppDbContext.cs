using Microsoft.EntityFrameworkCore;
using BooksApi.Models;


namespace BooksApi.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}
