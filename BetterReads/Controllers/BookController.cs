using BetterReads.Api.Request.Book;
using BetterReads.Api.Response.Book;
using BetterReads.Api.ViewModels;
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
    [Route("{ISBN}")]
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
    /// <param name="request">A representation of the book to be added.</param>
    /// <remarks>
    /// Sample value of message
    /// 
    ///     POST /Book
    ///     {
    ///        "iSBN": "9780593135204",
    ///        "name": "Project Hail Mary"
    ///        "author": "Andy Weir"
    ///        "pages": "496"
    ///        "genre": "1"
    ///     }
    ///     
    /// </remarks>
    /// <returns> A CreateBookResponse <see cref="CreateBookResponse"/>.</returns>
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request )
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }

    /// <summary>
    /// Update an existing Book
    /// </summary>
    /// <param name="ISBN">A string which represents the ISBN (International Standard Book Number) of a book.</param>
    /// <param name="updatedBook">Represents the updated value of the book.</param>
    /// <returns> A UpdateBookResponse <see cref="CreateBookResponse"/>.</returns>
    [HttpPatch]
    [Route("{ISBN}")]
    public async Task<IActionResult> UpdateBook(string ISBN, [FromBody] UpdateBookViewModel updatedBook)
    {
        var request = new UpdateBookRequest
        {
            ISBN = ISBN,
            Name = updatedBook.Name,
            Author = updatedBook.Author,
            Pages = updatedBook.Pages,
            Genre = updatedBook.Genre
        };

        var result = await mediator.Send(request);

        return Ok(result);
    }
}