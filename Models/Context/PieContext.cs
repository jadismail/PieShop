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
}