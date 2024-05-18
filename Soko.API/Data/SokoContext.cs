using Soko.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Data;


public class SokoContext(DbContextOptions<SokoContext> options)
    : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new { CategoryId = 1, CategoryName = "Foods" },
            new { CategoryId = 2, CategoryName = "Kitchen" },
            new { CategoryId= 3, CategoryName = "Electronics" },
            new { CategoryId= 4, CategoryName = "Toys" },
            new { CategoryId = 5, CategoryName = "Fruits" }
        );
    }
}