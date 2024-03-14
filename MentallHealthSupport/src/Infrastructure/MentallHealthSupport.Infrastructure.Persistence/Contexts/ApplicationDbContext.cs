using MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations.Configurations;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    //required public DbSet<UserModel> Users { get; set; }
    
    required public DbSet<SpotModel> Spots { get; set; }
    
    required public DbSet<SessionModel> Sessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        
        modelBuilder.ApplyConfiguration(new SpotConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}