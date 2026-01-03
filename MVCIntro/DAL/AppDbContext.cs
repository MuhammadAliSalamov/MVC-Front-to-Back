using Microsoft.EntityFrameworkCore;
using MVCIntro.Models;

namespace MVCIntro.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Slide> Slides { get; set; }
    public DbSet<Category> Categories { get; set; }

}
