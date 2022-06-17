using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;
using System.Net;
using EmployeeManagement.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyBusiness companyBusiness;
        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
            companyBusiness = new CompanyBusiness();
        }

        [HttpPost("SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(CompanyCreateModel company)
        {
            return await companyBusiness.SaveCompanyAsync(company);
        }

        [HttpGet("GetCompanyById")]
        public async Task<IActionResult> GetById(int companyId)
        {
            var company = await companyBusiness.GetCompanyAsync(companyId);
            if (company != null)
            {
                return Ok(company);
            }
            return BadRequest();
        }


        [HttpPut("UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(CompanyViewModel company)
        {
            return await this.companyBusiness.UpdateCompanyAsync(company);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteById(int id)
        {
            return await companyBusiness.DeleteCompanyAsync(id);
        }
        [HttpGet("GetAllCompany")]
        public async Task<IActionResult> GetAllCompany()
        {
            var companies =  await companyBusiness.GetAllComapnyAsync();
            if (companies != null)
            {
                return Ok(companies);
            }
            return NoContent();
        }
    }
}
