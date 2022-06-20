using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("SaveRoles")]
        public async Task<HttpStatusCode> SaveEmployee(RoleGetModel role)
        {
            return await RoleBusiness.SaveRoleAsync(role);
        }


        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await RoleBusiness.GetAllRoleAsync();
            if (roles != null)
            {
                return Ok(roles);
            }
            return NoContent();
        }

    }
}
