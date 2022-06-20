using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;
using EmployeeManagement.Data;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut(Name = "UpdateUser")]
        public async Task<HttpStatusCode> UpdateEmployee(UserUpdateModel user)
        {
            return await userBusiness.UpdateUserAsync(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete(Name = "DeleteUser")]
        public async Task<IActionResult> DeleteById(int UserId)
        {
            var user = await userBusiness.DeleteUserAsync(UserId);
            return Ok(user);
        }
    }
}
