using System.Net;
using BetterReads.Api.Exceptions.Infrastructure;

namespace BetterReads.Api.Exceptions.PageNumberNotValid
{
    public class PageNumberNotValidExceptionHandler : IHttpContextExceptionHandler<PageNumberNotValidException>
    {
        public async Task HandleAsync( HttpContext context, PageNumberNotValidException exception )
        {
            var response = new PageNumberNotValidResponse( exception );

            await context.Response.WriteJsonAsync(HttpStatusCode.BadRequest, response);
        }
    }
}