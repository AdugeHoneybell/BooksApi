using Microsoft.AspNetCore.Mvc;
using BooksApi.Models;

namespace BooksApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static List<Book> books = new();


    // This endpoint returns a list of all books in the collection.
    [HttpGet]
    public ActionResult<List<Book>> GetBooks()
    {
        return books;
    }


    // This endpoint returns a specific book by its ID.
    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);

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
        books.Add(book);

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }


    // This endpoint updates an existing book by its ID.
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book updatedBook)
    {
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;

        return NoContent();
    }


    // This endpoint deletes a book by its ID.
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        books.Remove(book);

        return NoContent();
    }
} 