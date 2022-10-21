using EmployeeManagement.Data;
using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly CompanyBusiness _companyBusiness;
        private readonly EmployeeBuisness _employeeBusiness;
        private readonly UserBusiness _userBusiness;
        public CommonController()
        {
            this._companyBusiness = new CompanyBusiness();
            this._employeeBusiness = new EmployeeBuisness();
            this._userBusiness = new UserBusiness();
        }

        [HttpGet("GetStatistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var employees = await this._employeeBusiness.GetAllEmployeeAsync();
            var companies = await this._companyBusiness.GetAllComapnyAsync();
            var users = await this._userBusiness.GetAllUsersAsync();

            var statistic = new StatisticsModel
            {
                TotalCompany = companies.Count,
                TotalEmployee = employees.Count,
                TotalUser = users.Count,
            };
            return Ok(statistic);
        }
    }
}
