namespace BetterReads.Api.Exceptions.Infrastructure
{
    /// <summary>
    /// Defines an interface for a <see cref="HttpContext"/> exception handler.
    /// </summary>
    /// <typeparam name="TException">The type of exception thrown.</typeparam>
    public interface IHttpContextExceptionHandler<in TException>
        where TException : Exception
    {
        /// <summary>
        /// Handles the specified <paramref name="exception"/> for the given <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="exception">The exception that was thrown.</param>
        /// <returns>An asynchronous operation.</returns>
        Task HandleAsync( HttpContext context, TException exception );
    }
}