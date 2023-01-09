using BetterReads.Api.Response.Book;
using BetterReads.Data.Enums;
using MediatR;

namespace BetterReads.Api.Request.Book
{
    public class CreateBookRequest : IRequest<CreateBookResponse>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
    }
}