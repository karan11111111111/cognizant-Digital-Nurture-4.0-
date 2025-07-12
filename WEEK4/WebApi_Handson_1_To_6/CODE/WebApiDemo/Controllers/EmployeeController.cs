using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Filters;
using WebApiDemo.Models;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthFilter]
    [Authorize(Roles = "Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return BadRequest("Invalid employee id");

            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            var createdEmployee = _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(Get), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var updatedEmployee = _employeeService.UpdateEmployee(id, employee);
            if (updatedEmployee == null)
                return BadRequest("Invalid employee id");

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            _employeeService.DeleteEmployee(id);
            return NoContent();
        }
    }
}