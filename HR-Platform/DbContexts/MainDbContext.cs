using AdAstra.HRPlatform.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

public class MainDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public MainDbContext(DbContextOptions<MainDbContext> options, IConfiguration configuration) : base(options) {
        _configuration = configuration;
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<CandidateInfo> CandidateInfos { get; set; }
    public DbSet<SkillTag> SkillTags { get; set; }
    public DbSet<ScheduleTag> ScheduleTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var scheduleTags = _configuration.GetSection("ScheduleTags").Get<List<string>>();

        modelBuilder.Entity<ScheduleTag>().HasData(
            scheduleTags.Select((tag, index) => new ScheduleTag
            {
                Id = index + 1,
                Name = tag
            })
        );

        var skillTags = _configuration.GetSection("SkillTags").Get<List<string>>();

        modelBuilder.Entity<SkillTag>().HasData(
            skillTags.Select((tag, index) => new SkillTag
            {
                Id = index + 1,
                Name = tag
            })
        );
    }

    public override int SaveChanges()
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
            .Select(e => e.Entity)
            .ToList();

        foreach (var entity in entities)
        {
            var validationContext = new ValidationContext(entity);
            Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
        }

        return base.SaveChanges();
    }
}