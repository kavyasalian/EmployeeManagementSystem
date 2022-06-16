using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RollController : Controller
    {

        private readonly ILogger<RollController> _logger;
        private readonly RollBusiness RollBusiness;
        public RollController(ILogger<RollController> logger)
        {
            _logger = logger;
            RollBusiness = new RollBusiness();
        }
        [HttpPost("SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(Roll roll)
        {
            return await RollBusiness.SaveCompanyAsync(roll);
        }
    }
}
