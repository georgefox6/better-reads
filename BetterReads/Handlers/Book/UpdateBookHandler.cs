using BetterReads.Api.Request.Book;
using BetterReads.Api.Response;
using BetterReads.Api.Response.Book;
using BetterReads.Data;
using MediatR;
using System.Text.RegularExpressions;
using BetterReads.Api.Exceptions.ISBNNotValid;
using BetterReads.Api.Exceptions.PageNumberNotValid;
using BetterReads.Api.Exceptions.BookNotFound;
using Microsoft.EntityFrameworkCore;

namespace BetterReads.Api.Handlers.Book
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
    {
        private readonly BetterReadsContext context;
        private readonly ILogger<UpdateBookHandler> logger;

        public UpdateBookHandler(BetterReadsContext context, ILogger<UpdateBookHandler> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.ISBN))
            {
                logger.LogWarning("The ISBN supplied is not valid. Null.");
                throw new ISBNNotValidException();
            }

            var book = await context.Books.FirstOrDefaultAsync(x => x.ISBN == request.ISBN, cancellationToken);

            if (book == null)
            {
                logger.LogWarning("A book with that ISBN has not been found");
                throw new BookNotFoundException();
            }

            if (!Regex.Match(request.ISBN, @"^[0-9]{13}$").Success)
            {
                logger.LogWarning("The ISBN supplied is not valid. The value should be 13 numeric characters.");
                throw new ISBNNotValidException();
            }

            if (!IsValidPageNumber(request.Pages))
            {
                logger.LogWarning("The number of pages supplied is not valid. The value should be between 1 and 3031");
                throw new PageNumberNotValidException();
            }
            
            book.Name = request.Name;
            book.Author = request.Author;
            book.Pages = request.Pages;
            book.Genre = request.Genre;

            await context.SaveChangesAsync(cancellationToken);
            
            var response = new UpdateBookResponse
            {
                ISBN = book.ISBN,
                Name = book.Name,
                Author = book.Author,
                Pages = book.Pages,
                Genre = book.Genre,
                Links = new List<ResponseLink>
                {
                    new ResponseLink
                    {
                        Entity = "Book",
                        Action = "GET",
                        URL = "/Book/<ISBN>"
                    },
                    new ResponseLink
                    {
                        Entity = "Book",
                        Action = "POST",
                        URL = "/Book/<ISBN>"
                    }
                }
            };
            return response;
        }

        /// <summary>
        /// Checks the validity of the number of pages supplied by the user.
        /// </summary>
        /// <param name="pages"></param>
        /// <returns></returns>
        public bool IsValidPageNumber(int pages)
        {
            switch (pages)
            {
                case < 1:
                case > 3031:
                    return false;
                default:
                    return true;
            }
        }
    }
}