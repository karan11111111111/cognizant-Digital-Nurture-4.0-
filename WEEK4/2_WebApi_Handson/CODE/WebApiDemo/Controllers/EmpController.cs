using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [Route("api/emp")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmpController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return _employeeService.GetAllEmployees();
        }
    }
}