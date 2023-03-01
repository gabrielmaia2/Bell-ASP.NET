using Bell.DB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Hosting;

namespace Bell.DB.Data;

public class BellContext : DbContext
{
    private readonly IWebHostEnvironment env;

    public BellContext(DbContextOptions<BellContext> options, IWebHostEnvironment env)
        : base(options)
    {
        this.env = env;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (env.IsDevelopment())
            ConfigureDevelopment(modelBuilder);
        modelBuilder.Entity<ProductDB>().ToTable("Product");
    }

    // Maps types invalid to SQLite into valid types.
    private void ConfigureDevelopment(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDB>().Property(p => p.Id)
            .HasConversion(
                id => (int)id,
                id => (ulong)id
            );
    }

    public DbSet<ProductDB> Products { get; set; }
}
