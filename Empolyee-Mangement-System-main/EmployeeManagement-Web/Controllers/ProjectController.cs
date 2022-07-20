using EmployeeManagement.Data;
using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly ProjectBusiness projectBusiness;
        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
            projectBusiness = new ProjectBusiness();
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
        [HttpPost("SaveProject")]
        public async Task<IActionResult> SaveProject(ProjectCreateModel project)
        {
            var status = await projectBusiness.SaveProjectAsync(project);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }


        [HttpPut("UpdateProject")]
        public async Task<IActionResult> UpdateProject(ProjectGetModel project)
        {
            var status = await this.projectBusiness.UpdateProjectAsync(project);

            if (status == HttpStatusCode.OK)
            {
                return Ok(status);
            }
            return BadRequest(status);


        }
    }
}
