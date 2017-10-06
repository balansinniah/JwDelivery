using EntityFramework.Core.Generic;

namespace JwDelivery.Data.SqlServer.Models
{
    public class Status : IEntity
    {
        public long StatusId { get; set; }
        public string Description { get; set; }
    }
}
