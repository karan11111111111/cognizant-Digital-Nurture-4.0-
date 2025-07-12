using WebApiDemo.Models;

namespace WebApiDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Salary = 50000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "IT" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "ASP.NET Core" }
                },
                DateOfBirth = new DateTime(1990, 1, 1)
            }
        };

        public List<Employee> GetAllEmployees() => _employees;

        public Employee GetEmployeeById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null) return null;

            existing.Name = employee.Name;
            existing.Salary = employee.Salary;
            existing.Permanent = employee.Permanent;
            existing.Department = employee.Department;
            existing.Skills = employee.Skills;
            existing.DateOfBirth = employee.DateOfBirth;

            return existing;
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}