using BetterReads.Api.Response.Book;
using MediatR;

namespace BetterReads.Api.Request.Book
{
    public class GetBookRequest : IRequest<GetBookResponse>
    {
        public string ISBN { get; set; }
    }
}
