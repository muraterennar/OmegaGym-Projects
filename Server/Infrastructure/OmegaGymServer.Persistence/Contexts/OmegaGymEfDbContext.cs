using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Persistence.Contexts;

public class OmegaGymEfDbContext : DbContext
{

    public OmegaGymEfDbContext()
    {

    }

    public OmegaGymEfDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserSubscription> UserSubscriptions { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<SubscriptionCategory> SubscriptionCategories { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Franchising> Franchisings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connStr = "*********";
            optionsBuilder.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Otomatik created date ve updated date doldurma
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            if (data.State == EntityState.Added)
                data.Entity.CreatedDate = DateTime.Now;

            if (data.State == EntityState.Modified)
                data.Entity.UpdatedDate = DateTime.Now;
        }

        // Otomatik her üye olan kişiye user rolunu atama
        var datasRegisters = ChangeTracker.Entries<User>();
        foreach (var data in datasRegisters)
        {
            if (data.State == EntityState.Added)
            {
                var opClm = OperationClaims.FirstOrDefault(u => u.RoleName == "user");

                if (data.Entity.OperationClaimId == Guid.Empty)
                    data.Entity.OperationClaimId = opClm.Id;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}

