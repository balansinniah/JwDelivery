using EntityFramework.Core.Generic;
using System;
using System.Collections.Generic;

namespace JwDelivery.Data.SqlServer.Models
{
    public class Employee : IEntity
    {
        public long EmployeeId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Notes { get; set; }

        public List<EmployeeAddress> Addresses { get; set; }
        public List<EmployeeRate> EmployeeRates { get; set; }
        public List<EmployeeAudit> EmployeeAudits { get; set; }

    }
}
