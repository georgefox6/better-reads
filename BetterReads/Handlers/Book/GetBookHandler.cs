using BetterReads.Api.Exceptions.BookNotFound;
using BetterReads.Api.Request.Book;
using BetterReads.Api.Response;
using BetterReads.Api.Response.Book;
using BetterReads.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using BetterReads.Api.Exceptions.ISBNNotValid;

namespace BetterReads.Api.Handlers.Book
{
    public class GetBookHandler : IRequestHandler<GetBookRequest, GetBookResponse>
    {
        private readonly BetterReadsContext context;
        private readonly ILogger<GetBookHandler> logger;

        public GetBookHandler(BetterReadsContext context, ILogger<GetBookHandler> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<GetBookResponse> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.ISBN))
            {
                throw new ISBNNotValidException();
            }

            if (!Regex.Match(request.ISBN, @"^[0-9]{13}$").Success)
            {
                throw new ISBNNotValidException();
            }

            var book = await context.Books.FirstOrDefaultAsync(x => x.ISBN == request.ISBN, cancellationToken);

            if (book == null)
            {
                logger.LogError("A book with that ISBN has not been found");
                throw new BookNotFoundException();
            }

            var response = new GetBookResponse
            {
                ISBN = book.ISBN,
                Name = book.Name,
                Author = book.Author,
                Pages = book.Pages,
                Genre = book.Genre,
                Links = new List<ResponseLink>
                {

                }
            };

            return response;
        }
    }
}