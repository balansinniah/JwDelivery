namespace JwDelivery.Data.SqlServer.Models
{
    public class EmployeeAudit : AuditableEntity
    {
        public long EmployeeAuditId { get; set; }
        public long EmployeeId { get; set; }
        public long StatusId { get; set; }
        public Employee Employee { get; set; }
        public Status Status { get; set; }
    }
}
