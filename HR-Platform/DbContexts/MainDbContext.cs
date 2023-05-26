using AdAstra.HRPlatform.API.Entities;
using AdAstra.HRPlatform.API.Entities.Base;
using AdAstra.HRPlatform.API.Entities.Roles;
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
    public DbSet<Role> Roles { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
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

        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany()
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<AdminRole>().ToTable("AdminRoles");
        modelBuilder.Entity<HrbrRole>().ToTable("HRBRRoles");
        modelBuilder.Entity<HRManagerRole>().ToTable("HRManagerRoles");
        modelBuilder.Entity<EmployerRole>().ToTable("EmployerRoles");
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