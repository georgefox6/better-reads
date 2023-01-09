namespace BetterReads.Api.Exceptions.BookNotFound
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException() : base( "The book could not be found." ) { }
    }
}