using BetterReads.Api.Response.Book;
using BetterReads.Data.Enums;
using MediatR;

namespace BetterReads.Api.Request.Book
{
    /// <summary>
    /// <param name="ISBN">A string which represents the ISBN (International Standard Book Number) of a book.</param>
    /// <param name="Name">A string which represents the name of the book.</param>
    /// <param name="Author">A string which represents the name of the Author of the book.</param>
    /// <param name="Pages">An integer which represents the number of pages in the book.</param>
    /// <param name="Genre">Represents the genre of a book.</param>
    /// </summary>
    public class CreateBookRequest : IRequest<CreateBookResponse>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
    }
}