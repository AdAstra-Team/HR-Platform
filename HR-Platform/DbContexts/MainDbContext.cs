using AdAstra.HRPlatform.Entities;
using Microsoft.EntityFrameworkCore;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
}