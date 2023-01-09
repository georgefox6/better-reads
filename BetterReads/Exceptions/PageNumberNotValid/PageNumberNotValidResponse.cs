using BetterReads.Api.Exceptions.Infrastructure;

namespace BetterReads.Api.Exceptions.PageNumberNotValid
{
    public class PageNumberNotValidResponse : ExceptionResponse<PageNumberNotValidException>
    {
        public PageNumberNotValidResponse(PageNumberNotValidException exception ) : base("PageNumberNotValid", "The number of pages is invalid.", exception ) { }
    }
}