using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entites;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private List<ToDo> projects = new List<ToDo>();

        [HttpGet]
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int id)
        {
            var project = projects.Find(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPut("{id}")]
        public ActionResult<ToDo> Put(int id, ToDo updatedProject)
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
