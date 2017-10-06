using EntityFramework.Core.Generic.Pattern.Repository;
using JwDelivery.Data.SqlServer.Models;
using JwDelivery.Logistics.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JwDelivery.Logistics.Repositories.Contract
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetEmployeeById(long id);
         IEnumerable<Employee> GetEmployeeBySearchCriteria(EmployeeSearchCriteria criteria);
    }

}
