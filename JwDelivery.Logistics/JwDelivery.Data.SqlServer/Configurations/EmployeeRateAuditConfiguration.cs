using JwDelivery.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwDelivery.Data.SqlServer.Configurations
{
    public class EmployeeRateAuditConfiguration : IEntityTypeConfiguration<EmployeeRateAudit>
    {
        public void Configure(EntityTypeBuilder<EmployeeRateAudit> builder)
        {
            builder.ToTable("EmployeeRateAudit");
            builder.HasKey(c => c.EmployeeRateAuditId);
            builder.Property(e => e.EmployeeRateAuditId).ValueGeneratedOnAdd();
            builder.Property(e => e.AuditUser).HasMaxLength(100).IsRequired();
            builder.HasOne(e => e.EmployeeRate)
                .WithOne()
                .HasConstraintName("ForeignKey_EmployeeRateAudit_EmployeeRate")
                .IsRequired();


            builder.HasOne(e => e.Status)
                .WithOne()
                .HasConstraintName("ForeignKey_EmployeeRateAudit_Status")
                .IsRequired();
        }
    }
}
