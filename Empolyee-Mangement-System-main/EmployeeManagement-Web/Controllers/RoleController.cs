using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;
using System.Net;
using EmployeeManagement.Data;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {

        private readonly ILogger<RoleController> _logger;
        private readonly RoleBusiness RoleBusiness;
        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
            RoleBusiness = new RoleBusiness();
        }

        [HttpPut("UpdateRole")]
        public async Task<HttpStatusCode> UpdateRole(RoleViewModel roleView)
        {
            return await RoleBusiness.UpdateRoleAsync(roleView);
        }
    }
}
