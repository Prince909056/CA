using CleanArchitecture.Domain.Entities.EmailConfigEntities;
using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Persistence.Configurations;

namespace CleanArchitecture.Persistence.Context;
public class StrideMemoDbContext : DbContext
{
    public StrideMemoDbContext(DbContextOptions<StrideMemoDbContext> options) : base(options) { }
    public DbSet<User> users { get; set; }
    public DbSet<EmailConfig> emailConfigs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new EmailConfigConfiguration());
    }
}
