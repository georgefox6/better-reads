using BetterReads.Api.Exceptions.Infrastructure;

namespace BetterReads.Api.Exceptions.ISBNNotValid
{
    public class ISBNNotValidResponse : ExceptionResponse<ISBNNotValidException>
    {
        public ISBNNotValidResponse(ISBNNotValidException exception ) : base("ISBNNotValid", "The format of the ISBN is invalid.", exception ) { }
    }
}