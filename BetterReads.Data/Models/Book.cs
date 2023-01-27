using System.ComponentModel.DataAnnotations;
using BetterReads.Data.Enums;

namespace BetterReads.Data.Models;

public class Book : BaseEntity
{
    [Key]
    public string ISBN { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string AuthorLink { get; set; }
    public int Pages { get; set; }
    public Genre Genre { get; set; }
    public string GoodReadsLink { get; set; }
    public string? Series { get; set; }
    public DateTime PublishDate { get; set; }
    public string Publisher { get; set; }
    public string? Setting { get; set; }
    public string? Description { get; set; }
}