using EntityFramework.Core.Generic;
using JwDelivery.Data.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JwDelivery.Data.SqlServer.Context
{
    public class JwDeliveryContext : DbContext, IDbContext, IDbContextFactory
    {
        public JwDeliveryContext()
        {

        }
        public JwDeliveryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeAddressConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeAuditConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeRateAuditConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeRateConfiguration());
            modelBuilder.ApplyConfiguration(new RateTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());

        }

        public JwDeliveryContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JwDeliveryContext>();

            var connectionString = "";//"Server=localhost\\sqlserver2014;Database=JwDelivery;User Id=sa;Password=P@ssword01;Encrypt=True;TrustServerCertificate=True";

            builder.UseSqlServer(connectionString);

            return new JwDeliveryContext(builder.Options);
        }
    }
}
