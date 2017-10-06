using JwDelivery.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwDelivery.Data.SqlServer.Configurations
{
    public class EmployeeAuditConfiguration : IEntityTypeConfiguration<EmployeeAudit>
    {
        public void Configure(EntityTypeBuilder<EmployeeAudit> builder)
        {
            builder.ToTable("EmployeeAudit");
            builder.HasKey(c => c.EmployeeAuditId);
            builder.Property(e => e.EmployeeAuditId).ValueGeneratedOnAdd();
            builder.Property(e => e.AuditUser).HasMaxLength(100).IsRequired();
            builder.HasOne(e => e.Employee)
                .WithMany(a => a.EmployeeAudits)
                .HasForeignKey(e => e.EmployeeId)
                .HasConstraintName("ForeignKey_EmployeeAudit_Employee");

            builder.HasOne(e => e.Status)
                .WithOne()
                .HasConstraintName("ForeignKey_EmployeeAudit_Status")
                .IsRequired();
        }
    }
}
