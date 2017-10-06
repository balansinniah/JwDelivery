using System;

namespace JwDelivery.Logistics.Core.Dto
{
    public class EmployeeDto
    {
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
    }
}
