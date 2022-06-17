using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController :ControllerBase
    {
        private readonly RoleBusiness roleBusiness;
    }
}
