using EntityFramework.Core.Generic;

namespace JwDelivery.Data.SqlServer.Models
{
    public class RateType: IEntity
    {
        public long RateTypeId { get; set; }
        public string Description { get; set; }
    }
}
