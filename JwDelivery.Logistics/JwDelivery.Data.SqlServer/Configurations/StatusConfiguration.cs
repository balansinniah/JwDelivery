using JwDelivery.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwDelivery.Data.SqlServer.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("List_Status");
            builder.HasKey(c => c.StatusId);
            builder.Property(e => e.StatusId).ValueGeneratedOnAdd();
            builder.Property(e => e.Description).HasMaxLength(30).IsRequired();
        }
    }
}
