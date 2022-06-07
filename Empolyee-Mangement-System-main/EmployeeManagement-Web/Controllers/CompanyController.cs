using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Repository.Entities;
using System.Net;
using EmployeeManagement_Business;
using EmployeeManagement_Repository;


namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        
        private readonly CompanyBusiness companyBusiness;
        public CompanyController()
        {
            companyBusiness = new CompanyBusiness();
        }

        [HttpGet("GetAllCompany")]
        public async Task<List<EmployeeManagement_Repository.Entities.Company>> GetAllCompany()
        {
            return await companyBusiness.GetAllComapnyAsync();
        }
        [HttpGet(Name = "GetCompany")]
        public async Task<IActionResult> GetById(int CompanyId)
        {
            var company = await companyBusiness.GetCompanyAsync(CompanyId);
            return Ok(company);
        }
        [HttpPost(Name = "SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(EmployeeManagement_Repository.Entities.Company company)
        {
            return await companyBusiness.SaveCompanyAsync(company);
        }
        [HttpPut(Name = "UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(EmployeeManagement_Repository.Entities.Company company)
        {
            return await companyBusiness.UpdateCompanyAsync(company);
        }
        [HttpDelete(Name = "DeleteCompany")]
        public async Task<IActionResult> DeleteById(int CompanyId)
        {
            var company = await companyBusiness.DeleteCompanyAsync(CompanyId);
            return Ok(company);
        }
    }
}
