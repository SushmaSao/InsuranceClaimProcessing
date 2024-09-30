using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerService.Persistence.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.FirstName).IsRequired()
                  .HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DateOfBirth).IsRequired();
        }
    }
}
