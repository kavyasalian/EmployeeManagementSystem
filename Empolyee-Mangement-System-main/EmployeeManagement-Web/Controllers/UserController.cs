using EmployeeManagement.Data;
using EmployeeManagement_Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await userBusiness.GetAllUsersAsync();
            if (users != null)
            {
                return Ok(users);
            }
            return NoContent();
        }

        [HttpGet("GetUserById/{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var user = await userBusiness.GetUserByIdAsync(Id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("AddUser")]
        public async Task<IActionResult> SaveUser(UserCreateModel user)
        {
            if (user.RoleId == null)
            {
                user.RoleId = 1;
            }
            var status = await userBusiness.SaveUserAsync(user);

            if(status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateEmployee(UserUpdateModel user)
        {
            var status = await userBusiness.UpdateUserAsync(user);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }
        
        [HttpDelete("DeleteUser/{UserId}")]
        public async Task<IActionResult> DeleteById(int UserId)
        {
            var status = await userBusiness.DeleteUserAsync(UserId);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginmodel)
        {

            var login = await userBusiness.Login(loginmodel);
            if (login != null)
            {
                await userBusiness.PopulateJwtTokenAsync(login);
                var data = JsonConvert.SerializeObject(login);
                Response.Cookies.Append("ss", data);
                return Ok(login);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet("SearchByUserName")]
        public async Task<IActionResult> SearchByUserName(string userName)
        {
            var user = await userBusiness.SearchNameAsync(userName);

            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }
    }
}
