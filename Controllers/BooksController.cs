using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    // The controller uses dependency injection to get an instance of the AppDbContext.
    private readonly IBooksService _booksService;


    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }


    // This endpoint returns a list of all books in the collection.
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        var books = await _booksService.GetBooksAsync();
        return Ok(books);
    }


    // This endpoint returns a specific book by its ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _booksService.GetBookAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }


    // This endpoint creates a new book and adds it to the collection.
    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book)
    {
        var createdBook = await _booksService.CreateBookAsync(book);

        return CreatedAtAction(
            nameof(GetBook),
            new { id = createdBook.Id },
            createdBook
        );
    }


    // This endpoint updates an existing book by its ID.
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
    {
        var updated = await _booksService.UpdateBookAsync(id, updatedBook);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }


    // This endpoint deletes a book by its ID.
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var deleted = await _booksService.DeleteBookAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
} 