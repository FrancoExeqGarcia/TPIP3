using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private List<Data.Entities.ToDo> projects = new List<Data.Entities.ToDo>();

        [HttpGet]
        public ActionResult<IEnumerable<Data.Entities.ToDo>> Get()
        {
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<Data.Entities.ToDo> Get(int id)
        {
            var project = projects.Find(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPut("{id}")]
        public ActionResult<Data.Entities.ToDo> Put(int id, Data.Entities.ToDo updatedProject)
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
