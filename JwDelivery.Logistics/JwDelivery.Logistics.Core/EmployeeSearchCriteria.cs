using System;

namespace JwDelivery.Logistics.Core
{
    public class EmployeeSearchCriteria
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
