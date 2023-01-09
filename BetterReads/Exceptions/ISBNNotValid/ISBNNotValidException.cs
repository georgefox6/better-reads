namespace BetterReads.Api.Exceptions.ISBNNotValid
{
    public class ISBNNotValidException : Exception
    {
        public ISBNNotValidException() : base( "The format of the ISBN is invalid." ) { }
    }
}