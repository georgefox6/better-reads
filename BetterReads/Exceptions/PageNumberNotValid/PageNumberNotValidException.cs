namespace BetterReads.Api.Exceptions.PageNumberNotValid
{
    public class PageNumberNotValidException : Exception
    {
        public PageNumberNotValidException() : base( "The number of pages is not valid." ) { }
    }
}