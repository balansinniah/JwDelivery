using JwDelivery.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwDelivery.Data.SqlServer.Configurations
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.ToTable("EmployeeAddress");
            builder.HasKey(c => c.EmployeeAddressId);
            builder.Property(e => e.EmployeeAddressId).ValueGeneratedOnAdd();
            builder.Property(e => e.City).HasMaxLength(30).IsRequired(false);
            builder.Property(e => e.Country).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PostCode).HasMaxLength(10).IsRequired();
            builder.Property(e => e.Country).HasMaxLength(50).IsRequired();
            builder.Property(e => e.State).HasMaxLength(10).IsRequired();
            builder.Property(e => e.Street).HasMaxLength(100).IsRequired();
            builder.HasOne(e => e.Employee)
                .WithMany(a => a.Addresses)
                .HasForeignKey(e => e.EmployeeId)
                .HasConstraintName("ForeignKey_Employee_Address");

        }
    }
}
