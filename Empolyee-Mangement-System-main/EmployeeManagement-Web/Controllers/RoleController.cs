using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_Web.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
