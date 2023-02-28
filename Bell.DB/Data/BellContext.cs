using Bell.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Bell.DB.Data;

public class BellContext : DbContext
{
    public BellContext(DbContextOptions<BellContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDB>().ToTable("products");
    }

    public DbSet<ProductDB> Students { get; set; }
}
