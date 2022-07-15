using EmployeeManagement.Data;
using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly RoleBusiness RoleBusiness;
        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
            RoleBusiness = new RoleBusiness();
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

        [HttpPost("SaveRoles")]
        public async Task<IActionResult> SaveEmployee(RoleCreateModel role)
        {
            var status = await RoleBusiness.SaveRoleAsync(role);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(RoleGetModel roleView)
        {
            var status = await RoleBusiness.UpdateRoleAsync(roleView);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }
    }
}
