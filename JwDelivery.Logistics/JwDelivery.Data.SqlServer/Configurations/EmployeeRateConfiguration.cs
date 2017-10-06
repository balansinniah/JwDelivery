using JwDelivery.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwDelivery.Data.SqlServer.Configurations
{
    public class EmployeeRateConfiguration : IEntityTypeConfiguration<EmployeeRate>
    {
        public void Configure(EntityTypeBuilder<EmployeeRate> builder)
        {
            builder.ToTable("EmployeeRate");
            builder.HasKey(c => c.EmployeeRateId);
            builder.Property(e => e.EmployeeRateId).ValueGeneratedOnAdd();

            builder.HasOne(e => e.Employee)
                   .WithMany(a => a.EmployeeRates)
                   .HasForeignKey(e => e.EmployeeId)
                   .HasConstraintName("ForeignKey_Employee_Rate");

            builder.HasOne(e => e.RateType)
                   .WithOne()
                   .HasConstraintName("ForeignKey_Employee_RateType");
        }
    }
}
