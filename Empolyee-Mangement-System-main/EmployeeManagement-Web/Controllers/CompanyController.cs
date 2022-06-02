using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;
using System.Net;

namespace EmployeeManagement_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : Controller
{
    private readonly CompanyBusiness companyBusiness;
    public CompanyController()
    {
       this.companyBusiness = new CompanyBusiness();
    }

    [HttpGet("GetCompanyDetails")]
    public async Task<IActionResult> GetCompanyDetails(int Id)
    {
        var company= await this.companyBusiness.GetCompanyAsync(Id);
        if (company != null)
        {
            return Ok(company);
        }
        return BadRequest();


    }
}
