using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entites;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private List<Data.Entites.Task> projects = new List<Data.Entites.Task>();

        [HttpGet]
        public ActionResult<IEnumerable<Data.Entites.Task>> Get()
        {
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<Data.Entites.Task> Get(int id)
        {
            var project = projects.Find(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPut("{id}")]
        public ActionResult<Data.Entites.Task> Put(int id, Data.Entites.Task updatedProject)
        {
            var existingProject = projects.Find(p => p.Id == id);

            if (existingProject == null)
            {
                return NotFound();
            }

            existingProject.Name = updatedProject.Name;

            return Ok(existingProject);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var project = projects.Find(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            projects.Remove(project);

            return NoContent();
        }
    }
}
