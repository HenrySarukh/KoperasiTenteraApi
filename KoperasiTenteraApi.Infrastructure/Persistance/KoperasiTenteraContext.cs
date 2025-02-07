using KoperasiTenteraApi.Domain.Common;
using KoperasiTenteraApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KoperasiTenteraApi.Infrastructure.Persistance
{
    public class KoperasiTenteraContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Otp> Otps { get; set; }

        [ExcludeFromCodeCoverage]
        KoperasiTenteraContext()
        {
        }

        public KoperasiTenteraContext(DbContextOptions<KoperasiTenteraContext> options)
        : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (
                       e.State == EntityState.Added ||
                       e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((AuditableEntity)entityEntry.Entity).CreatedBy = "Need to add authentication";
                }
                else
                {
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                ((AuditableEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).UpdatedBy = "Need to add authentication";
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}