using BetterReads.Data.Enums;

namespace BetterReads.Api.ViewModels
{
    public record UpdateBookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
    }
}
