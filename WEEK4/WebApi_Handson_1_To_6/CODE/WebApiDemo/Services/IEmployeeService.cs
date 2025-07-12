using WebApiDemo.Models;

namespace WebApiDemo.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int id, Employee employee);
        void DeleteEmployee(int id);
    }
}