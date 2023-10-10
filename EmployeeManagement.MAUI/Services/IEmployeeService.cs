using UserManagement.MAUI.Models;

namespace UserManagement.MAUI.Services
{
    public interface IEmployeeService
    {
        Task<Employee> LoginEmployee(string username, string password);
        Task<List<Employee>> GetEmployeesExcept(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
        Task<bool> UpdateEmployee(int id, Employee employee);
    }
}
