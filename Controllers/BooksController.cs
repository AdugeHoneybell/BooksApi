using Microsoft.AspNetCore.Mvc;
using BooksApi.Models;

namespace BooksApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static List<Book> books = new();

    [HttpGet]
    public ActionResult<List<Book>> GetBooks()
    {
        return books;
    }
}