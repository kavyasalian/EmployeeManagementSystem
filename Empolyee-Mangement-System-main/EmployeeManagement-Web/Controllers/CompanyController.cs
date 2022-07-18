using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;
using System.Net;
using EmployeeManagement.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyBusiness companyBusiness;
        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
            companyBusiness = new CompanyBusiness();
        }

        [HttpGet("GetAllCompany")]
        public async Task<IActionResult> GetAllCompany()
        {
            var companies = await companyBusiness.GetAllComapnyAsync();
            if (companies != null)
            {
                return Ok(companies);
            }
            return NoContent();
        }

        [HttpGet("GetCompanyById/{companyId}")]
        public async Task<IActionResult> GetCompanyById(int companyId)
        {
            var company = await companyBusiness.GetCompanyByIdAsync(companyId);
            if (company != null)
            {
                return Ok(company);
            }
            return BadRequest();
        }

        [HttpPost("SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(CompanyCreateModel company)
        {
            return await companyBusiness.SaveCompanyAsync(company);
        }

        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(CompanyViewModel company)
        {
            var status = await this.companyBusiness.UpdateCompanyAsync(company);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);


        }

        [HttpDelete("DeleteCompanyById/{Id}")]
        public async Task<IActionResult> DeleteById(int Id)
        {
            var status = await companyBusiness.DeleteCompanyAsync(Id);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }
    }
}
