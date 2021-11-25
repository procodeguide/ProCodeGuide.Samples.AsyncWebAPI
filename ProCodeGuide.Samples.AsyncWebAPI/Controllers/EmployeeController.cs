using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProCodeGuide.Samples.AsyncWebAPI.Interfaces;
using ProCodeGuide.Samples.AsyncWebAPI.Models;

namespace ProCodeGuide.Samples.AsyncWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService? _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // POST api/<EmployeeController>
        [HttpGet("GetEmployees")]
        public List<Employee> GetEmployees()
        {
            return _employeeService.GetEmployees();
        }

        // POST api/<EmployeeController>
        [HttpGet("GetEmployeesAsync")]
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _employeeService.GetEmployeesAsync();
            }
            catch(Exception ex)
            {
                //Log the exception
                return null;
            }
        }
    }
}
