namespace BetterReads.Data.Models;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}