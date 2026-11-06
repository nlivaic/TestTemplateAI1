using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using TestTemplateAI1.Common.Base;
using TestTemplateAI1.Core.Entities;

namespace TestTemplateAI1.Data;

public class TestTemplateAI1DbContext : DbContext
{
    public TestTemplateAI1DbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Foo> Foos { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateVersionableEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();

        modelBuilder.Entity<Foo>(entity =>
        {
            entity.Property("RowVersion")
                .IsRowVersion();
        });
    }

    private void UpdateVersionableEntities()
    {
        if (!ChangeTracker.HasChanges())
        {
            return;
        }
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is IVersionedEntity)
            {
                item.OriginalValues["RowVersion"] = item.CurrentValues["RowVersion"];
            }
        }
    }
}
