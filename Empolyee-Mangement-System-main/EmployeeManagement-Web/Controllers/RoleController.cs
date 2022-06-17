using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {

        private readonly ILogger<RoleController> _logger;
        private readonly RoleBusiness RoleBusiness;
        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
            RoleBusiness = new RoleBusiness();
        }
        [HttpPost("SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(Role role)
    {
            return await RoleBusiness.SaveCompanyAsync(role);
        }
    }
}
