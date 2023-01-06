using BetterReads.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BetterReads.Data;

public class BetterReadsContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public BetterReadsContext()
    {
    }

    public BetterReadsContext(DbContextOptions<BetterReadsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        var connectionString = "Data Source=.;Initial Catalog=BetterReadsDatabase;Integrated Security=True;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(connectionString);
    }
}
