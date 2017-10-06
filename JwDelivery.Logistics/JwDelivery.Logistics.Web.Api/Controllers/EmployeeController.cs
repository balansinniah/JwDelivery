using AutoMapper;
using JwDelivery.Data.SqlServer.Models;
using JwDelivery.Logistics.Core.Dto;
using JwDelivery.Logistics.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JwDelivery.Logistics.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _service;
        public EmployeeController(IMapper mapper, IEmployeeService service)
        {
            _mapper     = mapper;
            _service    = service;
        }
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<EmployeeDto> Get(long id)
        {
            try
            {
                var emp      = await _service.GetEmployeeById(id);
                var employee = _mapper.Map<EmployeeDto>(emp);
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // POST: api/Employee
        [HttpPost]
        public async Task Post([FromBody]EmployeeDto employee)
        {
            try
            {
                if (!ModelState.IsValid) return;
                var emp = _mapper.Map<Employee>(employee);
                await _service.AddEmployee(emp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task Put(long id, [FromBody]EmployeeEditDto employee)
        {
            try
            {
                if (!ModelState.IsValid) return;
                await _service.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _service.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
