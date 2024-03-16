using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() {}
    public ApplicationDbContext(DbContextOptions options) : base(options) {}
    public required DbSet<ReviewModel> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        //modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}