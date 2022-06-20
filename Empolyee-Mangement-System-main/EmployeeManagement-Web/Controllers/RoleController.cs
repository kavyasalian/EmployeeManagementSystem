using EmployeeManagement.Data;
using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpGet("GetCompanyById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var role = await RoleBusiness.GetRoleAsync(Id);

            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest(role);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int Id)
        {
            var role = await RoleBusiness.DeleteRoleAsync(Id);
            return Ok(role);
        }

        [HttpPut("UpdateRole")]
        public async Task<HttpStatusCode> UpdateRole(RoleViewModel roleView)
        {
            return await RoleBusiness.UpdateRoleAsync(roleView);
        }
    }
}
