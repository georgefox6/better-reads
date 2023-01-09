using BetterReads.Api.Request.Book;
using BetterReads.Api.Response.Book;
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
}