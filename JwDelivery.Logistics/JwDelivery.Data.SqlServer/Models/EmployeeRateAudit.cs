namespace JwDelivery.Data.SqlServer.Models
{
    public class EmployeeRateAudit : AuditableEntity
    {
        public long EmployeeRateAuditId { get; set; }
        public long EmployeeRateId { get; set; }
        public long StatusId { get; set; }
        public EmployeeRate EmployeeRate { get; set; }
        public Status Status { get; set; }

    }
}
