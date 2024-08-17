using Microsoft.EntityFrameworkCore;

namespace PieShop.Models.Context;

public class PieContext : DbContext
{
    public DbSet<Pie> Pies { get; set; }
    public DbSet<Category> Categories { get; set; }

    public PieContext(DbContextOptions<PieContext> options) : base(options)
    {
        //
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pie>().HasData(
            new Pie { PieId = 1, Name = "Apple Pie", ShortDescription = "Delicious apple pie", Price = 12.99m },
            new Pie { PieId = 2, Name = "Cherry Pie", ShortDescription = "Sweet cherry pie", Price = 15.99m },
            new Pie { PieId = 3, Name = "Pumpkin Pie", ShortDescription = "Autumn favourite pumpkin pie", Price = 14.99m }
        );
    }
}