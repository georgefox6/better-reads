using BetterReads.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterReads.Data;

public class BetterReadsContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BookRating> BookRatings { get; set; }
    public DbSet<UserBookInteraction> UserBookInteractions { get; set; }

    public BetterReadsContext()
    {
    }

    public BetterReadsContext(DbContextOptions<BetterReadsContext> options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt= DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt= DateTime.Now;
            }
        }
        return base.SaveChanges();
    }
}
