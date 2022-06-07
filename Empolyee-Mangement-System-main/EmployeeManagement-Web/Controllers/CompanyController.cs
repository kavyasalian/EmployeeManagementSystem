using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly CompanyBusiness _companyBuisness;
        public CompanyController()
        {
            this._companyBuisness = new CompanyBusiness();
        }

        [HttpPost("SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(Company company)
        {
            return await _companyBuisness.SaveCompanyAsync(company);
        }

        [HttpGet("GetCompanyById")]
        public async Task<IActionResult> GetById(int companyId)
        {
            var company = await _companyBuisness.GetCompanyAsync(companyId);
            if(company != null)
        {
                return Ok(company);
            }
            return BadRequest();
        }

        [HttpGet("GetAllCompany")]
        public async Task<List<Company>> GetAllEmployee()
        {
            return await _companyBuisness.GetAllCompaniesAsync();
        }

        [HttpPut("UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(Company company)
        {
            return await this._companyBuisness.UpdateCompanyAsync(company);
        }

        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteById(int companyId)
        {
            var employee = await _companyBuisness.DeleteCompanyAsync(companyId);
            return Ok(employee);
        }
    }
}
