using JwDelivery.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JwDelivery.Data.SqlServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<JwDeliveryContext>(
                options => options.UseSqlServer(connectionString));
        }
    }
}
