using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.AsyncWebAPI.DBEntities;
using ProCodeGuide.Samples.AsyncWebAPI.Interfaces;
using ProCodeGuide.Samples.AsyncWebAPI.Models;

namespace ProCodeGuide.Samples.AsyncWebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IApplicationDbContext _applicationDbContext;

        public EmployeeService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Employee> GetEmployees()
        {
            return AdaptEmployee(_applicationDbContext.Employees.ToList<EmployeeEntity>());
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return AdaptEmployee(await _applicationDbContext.Employees.ToListAsync<EmployeeEntity>());
        }

        private static List<Employee> AdaptEmployee(List<EmployeeEntity> employeeEntityList)
        {
            List<Employee> employeeList = new();

            Employee? employee;

            foreach (EmployeeEntity employeeEntity in employeeEntityList)
            {
                employee = new()
                {
                    FirstName = employeeEntity.FirstName,
                    MiddleName = employeeEntity.MiddleName,
                    LastName = employeeEntity.LastName,
                    Designation = employeeEntity.Designation
                };
                employeeList.Add(employee);
            }
            return employeeList;
        }
    }
}
