using EntityFramework.Core.Generic.Pattern.Repository;
using EntityFramework.Core.Generic.Pattern.Service;
using JwDelivery.Data.SqlServer.Models;
using JwDelivery.Logistics.Core.Dto;
using JwDelivery.Logistics.Repositories.Contract;
using JwDelivery.Logistics.Services.Contract;
using System.Threading.Tasks;

namespace JwDelivery.Logistics.Services.Implementation
{
    public class EmployeeService : EntityService<Employee>, IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _repository;
       
        public EmployeeService(IUnitOfWork unitOfWork, IEmployeeRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
           await _repository.Add(employee);
           var res = await _unitOfWork.Commit();
           return res;
        }

        public async Task<int> UpdateEmployee(EmployeeEditDto employee)
        {
            var emp = await _repository.GetEmployeeById(employee.Id);
            if (emp == null) return -1;
            emp.DateOfBirth = employee.DateOfBirth;
            emp.FirstName   = employee.FirstName;
            emp.DisplayName = employee.DisplayName;
            emp.LastName    = employee.LastName;
            emp.Mobile      = employee.Mobile;
            emp.Phone       = employee.Phone;
            emp.Email       = employee.Email;
            emp.Gender      = employee.Gender;
            var res         = await _unitOfWork.Commit();
            return res;
        }

        public async Task<int> DeleteEmployee(long employeeId)
        {
            var emp = await _repository.GetEmployeeById(employeeId);
            _repository.Delete(emp);
            var res = await _unitOfWork.Commit();
            return res;
        }

        public async Task<Employee> GetEmployeeById(long id)
        {
            return await _repository.GetEmployeeById(id);
        }
    }
}
