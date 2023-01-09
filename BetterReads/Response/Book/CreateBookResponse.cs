using BetterReads.Data.Enums;

namespace BetterReads.Api.Response.Book
{
    public class CreateBookResponse
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
        public IEnumerable<ResponseLink> Links { get; set; }
    }
}
