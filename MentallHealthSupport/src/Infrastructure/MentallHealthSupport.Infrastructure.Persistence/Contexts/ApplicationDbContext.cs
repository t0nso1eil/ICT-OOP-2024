using MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations.Configurations;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    required public DbSet<UserModel> Users { get; set; }
    
    required public DbSet<ChatModel> Chats { get; set; }
    
    required public DbSet<MessageModel> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.ApplyConfiguration(new ChatConfiguration());
        
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}