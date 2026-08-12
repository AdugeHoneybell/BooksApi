using BooksApi.Infrastructure;
using BooksApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    // The controller uses dependency injection to get an instance of the AppDbContext.
    private readonly AppDbContext _context;


    public BooksController(AppDbContext context)
    {
        _context = context;
    }


    // This endpoint returns a list of all books in the collection.
    [HttpGet]
    public ActionResult<List<Book>> GetBooks()
    {
        return _context.Books.ToList();
    }


    // This endpoint returns a specific book by its ID.
    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }


    // This endpoint creates a new book and adds it to the collection.
    [HttpPost]
    public ActionResult<Book> CreateBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }


    // This endpoint updates an existing book by its ID.
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book updatedBook)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        
        _context.SaveChanges();
        return NoContent();
    }


    // This endpoint deletes a book by its ID.
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        _context.SaveChanges();

        return NoContent();
    }
} 