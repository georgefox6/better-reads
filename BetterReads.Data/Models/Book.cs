using System.ComponentModel.DataAnnotations;
using BetterReads.Data.Enums;

namespace BetterReads.Data.Models;

public class Book
{
    [Key]
    public string ISBN { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public Genre Genre { get; set; }
}