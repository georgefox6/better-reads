using System.Net;
using BetterReads.Api.Exceptions.Infrastructure;

namespace BetterReads.Api.Exceptions.ISBNNotValid
{
    public class ISBNNotValidExceptionHandler : IHttpContextExceptionHandler<ISBNNotValidException>
    {
        public async Task HandleAsync( HttpContext context, ISBNNotValidException exception )
        {
            var response = new ISBNNotValidResponse( exception );

            await context.Response.WriteJsonAsync(HttpStatusCode.BadRequest, response);
        }
    }
}