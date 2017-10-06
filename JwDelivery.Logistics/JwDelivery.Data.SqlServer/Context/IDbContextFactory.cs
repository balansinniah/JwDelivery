using Microsoft.EntityFrameworkCore.Design;

namespace JwDelivery.Data.SqlServer.Context
{
    public interface IDbContextFactory : IDesignTimeDbContextFactory<JwDeliveryContext>
    {
    }
}
