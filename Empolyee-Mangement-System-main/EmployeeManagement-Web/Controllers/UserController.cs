using EmployeeManagement.Data;
using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserBusiness userBusiness;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            userBusiness = new UserBusiness();
        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await userBusiness.GetUsersListByIdAsync();

            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest(users);
            }
        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var user = await userBusiness.GetUserByIdAsync(Id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(user);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateEmployee(UserUpdateModel user)
        {
            return await userBusiness.UpdateUserAsync(user);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteById(int UserId)
        {
            var user = await userBusiness.DeleteUserAsync(UserId);
            return Ok(user);
        }
    }
}
