using Microsoft.EntityFrameworkCore;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    // Define your entity sets as DbSet properties here
    // Example: public DbSet<User> Users { get; set; }
}