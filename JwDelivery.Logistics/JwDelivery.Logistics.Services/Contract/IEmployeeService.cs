using EntityFramework.Core.Generic.Pattern.Service;
using JwDelivery.Data.SqlServer.Models;
using JwDelivery.Logistics.Core.Dto;
using System.Threading.Tasks;

namespace JwDelivery.Logistics.Services.Contract
{
    public interface IEmployeeService : IEntityService<Employee>
    {
        Task<Employee> GetEmployeeById(long id); 
        Task<int> AddEmployee(Employee employee);
        Task<int> UpdateEmployee(EmployeeEditDto employee);
        Task<int> DeleteEmployee(long employeeId);
    }
}
