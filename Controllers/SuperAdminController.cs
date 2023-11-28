using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOLIST.Data.Entites;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperAdminController : Controller
    {
        private List<Data.Entites.ToDo> projects = new List<Data.Entites.ToDo>();

        [HttpGet]
        public ActionResult<IEnumerable<Data.Entites.ToDo>> Get()
        {
            // Acciones específicas para superadministradores
            return Ok(projects);
        }

        // GET: AuperAdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuperAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuperAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuperAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuperAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuperAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuperAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuperAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
