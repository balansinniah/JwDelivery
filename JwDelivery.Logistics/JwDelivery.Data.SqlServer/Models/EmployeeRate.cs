using EntityFramework.Core.Generic;

namespace JwDelivery.Data.SqlServer.Models
{
    public class EmployeeRate : IEntity
    {
        public long EmployeeRateId { get; set; }
        public long EmployeeId { get; set; }
        public long RateTypeId { get; set; }
        public decimal Value { get; set; }
        public Employee Employee { get; set; }
        public RateType RateType { get; set; }
    }
}
