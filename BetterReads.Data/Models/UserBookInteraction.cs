using BetterReads.Data.Enums;

namespace BetterReads.Data.Models;

public class UserBookInteraction
{
    public int Id { get; set; }
    public User User { get; set; }
    public Book Book { get; set; }
    public BookStatus BookStatus { get; set; }
    public int? PagesRead { get; set; }
}