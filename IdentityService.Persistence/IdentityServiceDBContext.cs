using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Persistence
{
    public class IdentityServiceDBContext(DbContextOptions<IdentityServiceDBContext> options) : DbContext(options)
    {
        DbSet<Users> Users { get; set; }
        DbSet<Users> Roles { get; set; }
        DbSet<Users> UserRoles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityServiceDBContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = Guid.NewGuid(), Name = "User" },
                 new Roles { Id = Guid.NewGuid(), Name = "Agent" }
                );
        }

    }
}
