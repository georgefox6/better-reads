using BetterReads.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterReads.Data;

public class BetterReadsContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserBookInteraction> UserBookInteractions { get; set; }

    public BetterReadsContext()
    {
    }

    public BetterReadsContext(DbContextOptions<BetterReadsContext> options) : base(options)
    {
    }
}
