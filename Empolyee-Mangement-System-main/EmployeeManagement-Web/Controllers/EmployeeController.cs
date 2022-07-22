using EmployeeManagement.Data;
using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeBuisness employeeBusiness;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
            employeeBusiness = new EmployeeBuisness();
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployee()
        {
           var employees = await employeeBusiness.GetAllEmployeeAsync();
           return Ok(employees);
        }

        [HttpGet("GetEmployeeById/{Id}")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var employee = await employeeBusiness.GetEmployeeByIdAsync(Id);

            if (employee != null)
            {
                return Ok(employee);
            }

            return BadRequest(employee);
        }

        [HttpGet("FetchAllEmployeeByGender")]
        public async Task<IActionResult> FetchAllEmployeeByGender(String gender)
        {
            var employees = await employeeBusiness.FetchAllEmployeesAsync(gender);

            if (employees != null)
            {
                return Ok(employees);
            }

            return BadRequest(employees);
        }

        [HttpPost("SaveEmployee")]
        public async Task<IActionResult> SaveEmployee(EmployeeCreateModel employee)
        {
            var status = await employeeBusiness.SaveEmployeeAsync(employee);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(UpdateModelView employee)
        {
            var status = await employeeBusiness.UpdateEmployeeAsync(employee);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }

        [HttpDelete("DeleteEmployeeById/{employeeId}")]
        public async Task<IActionResult> DeleteById(int employeeId)
        {
            var status = await employeeBusiness.DeleteEmployeeAsync(employeeId);
            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }
        [HttpGet("SearchByEmployeeName")]
        public async Task<IActionResult> SearchByEmployeeName(string employeeName)
        {
            var employee = await employeeBusiness.SearchNameAsync(employeeName);

            if (employee != null)
            {
                return Ok(employee);
            }
                return BadRequest(employee);
        }
    }
}