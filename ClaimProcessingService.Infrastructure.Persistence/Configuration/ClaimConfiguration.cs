using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClaimProcessingService.Domain.Entities;

namespace ClaimProcessingService.Persistence.Configuration
{
    internal class ClaimConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.Property(e => e.CustomerId).IsRequired();
            builder.Property(e => e.IncidentDetails).IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.ClaimType).IsRequired();
            builder.Property(e => e.ClaimAmount).IsRequired();
            builder.Property(e => e.ClaimStatus).IsRequired();
            builder.Property(e => e.ClaimType).IsRequired();
        }
    }
}
