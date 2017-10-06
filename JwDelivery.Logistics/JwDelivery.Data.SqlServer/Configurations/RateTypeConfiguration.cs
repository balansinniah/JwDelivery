using JwDelivery.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwDelivery.Data.SqlServer.Configurations
{
    public class RateTypeConfiguration : IEntityTypeConfiguration<RateType>
    {
        public void Configure(EntityTypeBuilder<RateType> builder)
        {
            builder.ToTable("List_RateType");
            builder.HasKey(c => c.RateTypeId);
            builder.Property(e => e.RateTypeId).ValueGeneratedOnAdd();
            builder.Property(e => e.Description).HasMaxLength(30).IsRequired();

        }
    }
}
