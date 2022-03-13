using DemoWebApiWithSwagger.Interfaces;
using DemoWebApiWithSwagger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoWebApiWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> getEmployees()
        {
            try
            {
                return Ok(await _employeeService.getAllEmployees());
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting data from the database");
            }

        }
        [HttpGet]
        [Route("Id")]
        public async Task<IActionResult> getEmployee(int Id)
        {
            try
            {
                return Ok(await _employeeService.getEmployeeById(Id));
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting data from the database");
            }

        }

        [HttpPost]
        public async Task<IActionResult> addEmployee(Employee employee)
        {
            try
            {
                return Ok(await _employeeService.addEmployee(employee));
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting data from the database");
            }

        }
    }
}
