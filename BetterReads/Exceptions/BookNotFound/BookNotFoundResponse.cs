using BetterReads.Api.Exceptions.Infrastructure;

namespace BetterReads.Api.Exceptions.BookNotFound
{
    public class BookNotFoundResponse : ExceptionResponse<BookNotFoundException>
    {
        public BookNotFoundResponse( BookNotFoundException exception ) : base( "BookNotFound", "The book does not exist.", exception ) { }
    }
}