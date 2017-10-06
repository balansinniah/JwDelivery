using JwDelivery.Data.SqlServer.Models;
using System;

namespace JwDelivery.Logistics.xUnitTests
{
    public class TestDataFixture
    {
        public Employee Employee { get; } = new Employee
        {
            FirstName           = "Balan",
            LastName            = "Sinniah",
            DateOfBirth         = new DateTime(1973,3,19),
            Email               = "balan.sinniah@gmail.com",
            Gender              = "Male",
            Mobile              = "0402665434",
            Phone               = "0402665434"
        };
    }
}
