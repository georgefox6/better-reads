using BetterReads.Api.Request.Book;
using BetterReads.Api.Response.Book;
using BetterReads.Data.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BetterReads.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly ILogger<BookController> _logger;

    public BookController(IMediator mediator, ILogger<BookController> logger)
    {
        this.mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Get Book
    /// </summary>
    /// <param name="ISBN">A string which represents the ISBN (International Standard Book Number) of a book.</param>
    /// <returns> A GetBookResponse <see cref="GetBookResponse"/>.</returns>
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetBook(string ISBN)
    {
        var request = new GetBookRequest
        {
            ISBN = ISBN
        };
        var result = await mediator.Send(request);

        return Ok(result);
    }

    /// <summary>
    /// Create Book
    /// </summary>
    /// <param name="ISBN">A string which represents the ISBN (International Standard Book Number) of a book.</param>
    /// <param name="name">A string which represents the name of the book.</param>
    /// <param name="author">A string which represents the name of the Author of the book.</param>
    /// <param name="pages">An integer which represents the number of pages in the book.</param>
    /// <param name="genre">Represents the genre of a book.</param>
    /// <returns> A CreateBookResponse <see cref="CreateBookResponse"/>.</returns>
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateBook(string ISBN, string name, string author, int pages, Genre genre)
    {
        var request = new CreateBookRequest
        {
            ISBN = ISBN,
            Name = name,
            Author = author,
            Pages = pages,
            Genre = genre
        };
        var result = await mediator.Send(request);

        return Ok(result);
    }
}