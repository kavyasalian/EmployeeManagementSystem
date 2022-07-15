using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly ProjectBuisness projectBusiness;
        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
            projectBusiness = new ProjectBuisness();
        }

        // GET: api/<ProjectController>
        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProject()
        {
            var projects = await projectBusiness.GetAllProjectAsync();
            if (projects != null)
            {
                return Ok(projects);
            }
            return NoContent();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
