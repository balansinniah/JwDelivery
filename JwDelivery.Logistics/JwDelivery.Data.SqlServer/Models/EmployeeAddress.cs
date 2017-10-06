using EntityFramework.Core.Generic;

namespace JwDelivery.Data.SqlServer.Models
{
    public class EmployeeAddress : IEntity
    {
        public long EmployeeAddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
