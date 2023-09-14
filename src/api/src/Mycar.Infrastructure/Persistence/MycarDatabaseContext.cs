using Microsoft.EntityFrameworkCore;
using Mycar.Common.Types.Abstractions;
using Mycar.Domain.Cars;
using Mycar.Domain.Maintenance;

namespace Mycar.Infrastructure.Persistence;

public class MycarDatabaseContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Operation> Operations { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    public MycarDatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MycarDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        SetAuditFields();
        SetSoftDeleteMark();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetAuditFields()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e is { Entity: IAudit, State: EntityState.Added or EntityState.Modified });

        var currentUserId = new Guid(); //TODO: set current user here

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                ((IAudit)entry.Entity).CreatedDate = DateTime.UtcNow;
                ((IAudit)entry.Entity).CreatedByUserId = currentUserId;
            }

            ((IAudit)entry.Entity).LastModifiedDate = DateTime.UtcNow;
            ((IAudit)entry.Entity).LastModifiedUserId = currentUserId;
        }
    }

    private void SetSoftDeleteMark()
    {
        var entries = ChangeTracker.Entries().Where(e => e is { Entity: ISoftDelete, State: EntityState.Deleted });

        var currentUserId = new Guid(); //TODO: set current user here

        foreach (var entry in entries)
        {
            entry.State = EntityState.Modified;
            ((ISoftDelete)entry.Entity).IsDeleted = true;

            if (entry.Entity is IAudit audit)
            {
                audit.LastModifiedDate = DateTime.UtcNow;
                audit.LastModifiedUserId = currentUserId;
            }
        }
    }
}