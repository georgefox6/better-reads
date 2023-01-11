using BetterReads.Api.Request.Book;
using BetterReads.Api.Response;
using BetterReads.Api.Response.Book;
using BetterReads.Data;
using MediatR;
using System.Text.RegularExpressions;
using BetterReads.Api.Exceptions.ISBNNotValid;
using BetterReads.Api.Exceptions.PageNumberNotValid;

namespace BetterReads.Api.Handlers.Book
{
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        private readonly BetterReadsContext context;
        private readonly ILogger<CreateBookHandler> logger;

        public CreateBookHandler(BetterReadsContext context, ILogger<CreateBookHandler> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<CreateBookResponse> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.ISBN))
            {
                logger.LogWarning("The ISBN supplied is not valid. Null.");
                throw new ISBNNotValidException();
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

            var newBook = new Data.Models.Book
            {
                ISBN = request.ISBN,
                Name = request.Name,
                Author = request.Author,
                Pages = request.Pages,
                Genre = request.Genre
            };

            await context.Books.AddAsync(newBook, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            
            var response = new CreateBookResponse
            {
                ISBN = newBook.ISBN,
                Name = newBook.Name,
                Author = newBook.Author,
                Pages = newBook.Pages,
                Genre = newBook.Genre,
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
                        Action = "PATCH",
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