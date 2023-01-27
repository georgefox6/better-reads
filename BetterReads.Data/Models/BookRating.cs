namespace BetterReads.Data.Models;

public class BookRating : BaseEntity
{
    public int Id { get; set; }
    public Book Book { get; set; }
    public int FiveStarRatings { get; set; }
    public int FourStarRatings { get; set; }
    public int ThreeStarRatings { get; set; }
    public int TwoStarRatings { get; set; }
    public int OneStarRatings { get; set; }
}