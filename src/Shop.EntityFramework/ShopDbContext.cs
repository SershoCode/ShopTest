using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.EntityFramework;

public class ShopDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Product> Products { get; set; }

    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
#if DEBUG
        Database.EnsureCreated();
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(builder =>
        {
            builder.ToTable("Persons");
        });

        modelBuilder.Entity<Product>(builder =>
        {
            builder.ToTable("Products");
        });

        base.OnModelCreating(modelBuilder);
    }
}