using Microsoft.AspNetCore.Mvc;

namespace TODOLIST.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
