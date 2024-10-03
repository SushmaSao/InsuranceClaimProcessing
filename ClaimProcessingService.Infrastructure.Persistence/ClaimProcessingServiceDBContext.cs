using ClaimProcessingService.Domain.Common;
using ClaimProcessingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClaimProcessingService.Persistence
{
    public class ClaimProcessingServiceDBContext(DbContextOptions<ClaimProcessingServiceDBContext> options) : DbContext(options)
    {
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClaimProcessingServiceDBContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
