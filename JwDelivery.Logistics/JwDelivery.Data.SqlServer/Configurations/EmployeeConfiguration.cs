using JwDelivery.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwDelivery.Data.SqlServer.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(c => c.EmployeeId);
            builder.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            builder.Property(e => e.DisplayName).HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.Property(e => e.DateOfBirth).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Gender).HasMaxLength(10).IsRequired(false);
            builder.Property(e => e.HireDate).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.MiddleName).HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.Mobile).HasMaxLength(15).IsRequired();
            builder.Property(e => e.Notes).IsRequired(false);
            builder.Property(e => e.Phone).HasMaxLength(15).IsRequired(false);
            builder.Property(e => e.Title).HasMaxLength(10).IsRequired(false);
            builder.Property(e => e.ReleasedDate).IsRequired(false);
        }
    }
}