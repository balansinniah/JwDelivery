using EntityFramework.Core.Generic.Pattern.Repository;
using JwDelivery.Data.SqlServer.Context;
using JwDelivery.Logistics.Core;
using JwDelivery.Logistics.Core.Dto;
using JwDelivery.Logistics.Repositories.Implementation;
using JwDelivery.Logistics.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JwDelivery.Logistics.xUnitTests
{
    public class EmployeeRepositoryTest
    {
        private JwDeliveryContext InitContext()
        {
            var builder = new DbContextOptionsBuilder<JwDeliveryContext>()
                .UseInMemoryDatabase(new Guid().ToString());
            return new JwDeliveryContext(builder.Options);
        }

        [Theory]
        [InlineData("Balan", null, null, null, 0, 0, 0)]
        [InlineData(null, "Sinniah", null, null, 0, 0, 0)]
        [InlineData(null, null, "balan.sinniah@gmail.com", null, 0, 0, 0)]
        [InlineData(null, null, null, "0402665434", 0, 0, 0)]
        [InlineData(null, null, null, null, 1973, 3, 19)]
        [InlineData(null, null, null, null, 0, 0, 0)]
        [InlineData("Balan", null, null, "0402665434", 0, 0, 0)]
        [InlineData("Balan", "Sinniah", null, "0402665434", 0, 0, 0)]
        [InlineData("Balan", "Sinniah", "balan.sinniah@gmail.com", "0402665434", 0, 0, 0)]
        [InlineData("Balan", "Sinniah", "balan.sinniah@gmail.com", "0402665434", 1973, 3, 19)]
        public async Task Employee_Repo_Get_Employee_By_Search_Criteria_Return_Correct_Employee(string firstName, string lastName, string email, string mobile, int year, int month, int day)
        {
            using (var context = InitContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var fixture = new TestDataFixture();
                    var repo    = new EmployeeRepository(context);

                    var employees = repo.GetAll().ToList().Result;

                    repo.DeleteAll(employees);
                    var employee = fixture.Employee;

                    await repo.Add(employee);
                    await unitOfWork.Commit();
                    DateTime? dt = null;
                    if (year + month + day != 0)
                        dt = new DateTime(year, month, day);

                    var criteria = new EmployeeSearchCriteria
                    {
                        FirstName   = firstName,
                        LastName    = lastName,
                        BirthDate   = dt,
                        Email       = email,
                        Mobile      = mobile
                    };

                    var apps = repo.GetEmployeeBySearchCriteria(criteria).ToList();

                    Assert.True(apps.Any());
                }
            }
        }

        [Theory]
        [InlineData("John", null, null, null, 0, 0, 0)]
        [InlineData(null, "Sonny", null, null, 0, 0, 0)]
        [InlineData(null, null, "balan.sinniah@abc.com", null, 0, 0, 0)]
        [InlineData(null, null, null, "040111111", 0, 0, 0)]
        [InlineData(null, null, null, null, 1972, 4, 19)]
        [InlineData("Balan", null, null, null, 1972, 4, 19)]
        [InlineData(null, "Sinniah", null, null, 1972, 4, 19)]
        [InlineData(null, null, "balan.sinniah@gmail.com", null, 1972, 4, 19)]
        [InlineData(null, null, null, "0402665434", 1972, 4, 19)]
        public async Task Employee_Repo_Get_Employee_By_Invalid_Search_Criteria_Return_No_Employee(string firstName, string lastName, string email, string mobile, int year, int month, int day)
        {
            using (var context = InitContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var fixture = new TestDataFixture();
                    var repo    = new EmployeeRepository(context);

                    var employees = repo.GetAll().ToList().Result;

                    repo.DeleteAll(employees);
                    var employee = fixture.Employee;

                    await repo.Add(employee);
                    await unitOfWork.Commit();
                    DateTime? dt = null;
                    if (year + month + day != 0)
                        dt = new DateTime(year, month, day);

                    var criteria = new EmployeeSearchCriteria
                    {
                        FirstName   = firstName,
                        LastName    = lastName,
                        BirthDate   = dt,
                        Email       = email,
                        Mobile      = mobile
                    };

                    var apps = repo.GetEmployeeBySearchCriteria(criteria).ToList();

                    Assert.True(!apps.Any());
                }
            }
        }
        [Fact]
        public async Task Employee_Repo_Get_Employee_By_Id_Return_Correct_Employee()
        {
            using (var context = InitContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var fixture = new TestDataFixture();
                    var repo    = new EmployeeRepository(context);

                    var employees = repo.GetAll().ToList().Result;

                    repo.DeleteAll(employees);
                    var employee = fixture.Employee;

                    await repo.Add(employee);
                    await unitOfWork.Commit();

                    var id = employee.EmployeeId;

                    var emp = await repo.GetEmployeeById(id);

                    Assert.True(emp.EmployeeId == id);
                }
            }
        }
        [Theory]
        [InlineData("John")]
        public async Task Employee_Service_Update_Employee_FirstName_Return_Correct_Updated_Employee(string firstName)
        {
            using (var context = InitContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var fixture     = new TestDataFixture();
                    var repo        = new EmployeeRepository(context);
                    var service     = new EmployeeService(unitOfWork, repo);
                    var employees   = repo.GetAll().ToList().Result;

                    repo.DeleteAll(employees);
                    var employee = fixture.Employee;

                    await repo.Add(employee);
                    await unitOfWork.Commit();

                    var id = employee.EmployeeId;

                    //update the employee data
                    var empDto = new EmployeeEditDto
                    {
                        Id          = id,
                        DateOfBirth = employee.DateOfBirth,
                        DisplayName = employee.DisplayName,
                        FirstName   = firstName,
                        LastName    = employee.LastName,
                        Mobile      = employee.Mobile,
                        Email       = employee.Email,
                        Gender      = employee.Gender,
                        HireDate    = employee.HireDate,
                        ReleasedDate = employee.ReleasedDate
                    };

                    await service.UpdateEmployee(empDto);

                    var emp = await repo.GetEmployeeById(id);

                    Assert.True(emp.FirstName == firstName);
                }
            }
        }
        [Theory]
        [InlineData("John")]
        public async Task Employee_Service_Update_Employee_LastName_Return_Correct_Updated_Employee(string lastName)
        {
            using (var context = InitContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var fixture     = new TestDataFixture();
                    var repo        = new EmployeeRepository(context);
                    var service     = new EmployeeService(unitOfWork, repo);
                    var employees   = repo.GetAll().ToList().Result;

                    repo.DeleteAll(employees);
                    var employee = fixture.Employee;

                    await repo.Add(employee);
                    await unitOfWork.Commit();

                    var id = employee.EmployeeId;

                    //update the employee data
                    var empDto = new EmployeeEditDto
                    {
                        Id          = id,
                        DateOfBirth = employee.DateOfBirth,
                        DisplayName = employee.DisplayName,
                        FirstName   = employee.FirstName,
                        LastName    = lastName,
                        Mobile      = employee.Mobile,
                        Email       = employee.Email,
                        Gender      = employee.Gender,
                        HireDate    = employee.HireDate,
                        ReleasedDate = employee.ReleasedDate
                    };
                    await service.UpdateEmployee(empDto);

                    var emp = await repo.GetEmployeeById(id);

                    Assert.True(emp.LastName == lastName);
                }
            }
        }

        [Theory]
        [InlineData("John@gmail.com")]
        public async Task Employee_Service_Update_Employee_Email_Return_Correct_Updated_Employee(string email)
        {
            using (var context = InitContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var fixture     = new TestDataFixture();
                    var repo        = new EmployeeRepository(context);
                    var service     = new EmployeeService(unitOfWork, repo);
                    var employees   = repo.GetAll().ToList().Result;

                    repo.DeleteAll(employees);
                    var employee = fixture.Employee;

                    await repo.Add(employee);
                    await unitOfWork.Commit();

                    var id = employee.EmployeeId;

                    //update the employee data
                    var empDto = new EmployeeEditDto
                    {
                        Id          = id,
                        DateOfBirth = employee.DateOfBirth,
                        DisplayName = employee.DisplayName,
                        FirstName   = employee.FirstName,
                        LastName    = employee.LastName,
                        Mobile      = employee.Mobile,
                        Email       = email,
                        Gender      = employee.Gender,
                        HireDate    = employee.HireDate,
                        ReleasedDate = employee.ReleasedDate
                    };
                    await service.UpdateEmployee(empDto);

                    var emp = await repo.GetEmployeeById(id);

                    Assert.True(emp.Email == email);
                }
            }
        }
        [Fact]
        public async Task Employee_Service_Delete_Employee_Email_Return_Null_Employee()
        {
            using (var context = InitContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var fixture     = new TestDataFixture();
                    var repo        = new EmployeeRepository(context);
                    var service     = new EmployeeService(unitOfWork, repo);
                    var employees   = repo.GetAll().ToList().Result;

                    repo.DeleteAll(employees);
                    var employee = fixture.Employee;

                    await repo.Add(employee);
                    await unitOfWork.Commit();

                    var id = employee.EmployeeId;

                    //update the employee data
                    await service.DeleteEmployee(id);

                    var emp = await repo.GetEmployeeById(id);

                    Assert.True(emp == null);
                }
            }
        }
    }
}
