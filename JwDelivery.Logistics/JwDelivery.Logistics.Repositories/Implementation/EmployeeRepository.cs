using EntityFramework.Core.Generic;
using EntityFramework.Core.Generic.Pattern.Repository;
using JwDelivery.Data.SqlServer.Models;
using JwDelivery.Logistics.Core;
using JwDelivery.Logistics.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwDelivery.Logistics.Repositories.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContext context) : base(context)
        {
        }

        public  Task<Employee> GetEmployeeById(long id)
        {
            return Dbset.FindAsync(id);
        }

        public IEnumerable<Employee> GetEmployeeBySearchCriteria(EmployeeSearchCriteria criteria)
        {
            var dt = criteria.BirthDate?.Date ?? DateTime.MaxValue;
            var employees = Dbset.AsNoTracking().Where(p => (criteria.FirstName == null || string.Equals(p.FirstName, criteria.FirstName, StringComparison.CurrentCultureIgnoreCase)) &&
                                     (criteria.LastName == null || string.Equals(p.LastName, criteria.LastName, StringComparison.CurrentCultureIgnoreCase)) &&
                                     (criteria.Mobile == null || p.Mobile.Equals(criteria.Mobile, StringComparison.Ordinal)) &&
                                     (criteria.Email == null || string.Equals(p.Email, criteria.Email, StringComparison.CurrentCultureIgnoreCase)) &&
                                     (dt == DateTime.MaxValue || p.DateOfBirth.Date == dt.Date)
                               );

            return employees;

       }
    }
}
