using System.Net;
using BetterReads.Api.Exceptions.Infrastructure;

namespace BetterReads.Api.Exceptions.BookNotFound
{
    public class BookNotFoundExceptionHandler : IHttpContextExceptionHandler<BookNotFoundException>
    {
        public async Task HandleAsync( HttpContext context, BookNotFoundException exception )
        {
            var response = new BookNotFoundResponse( exception );

            await context.Response.WriteJsonAsync(HttpStatusCode.NotFound, response);
        }
    }
}