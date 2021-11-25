using ProCodeGuide.Samples.AsyncWebAPI.Models;

namespace ProCodeGuide.Samples.AsyncWebAPI.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Task<List<Employee>> GetEmployeesAsync();
    }
}
