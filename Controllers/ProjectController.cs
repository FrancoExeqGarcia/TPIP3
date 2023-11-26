using Microsoft.AspNetCore.Mvc;

namespace TODOLIST.Controllers
{
    public class ProjectController
    {
        [ApiController]
        [Route("api/[controller]")]

        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var project = projects.Find(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPut("{id}")]
        public ActionResult<Project> Put(int id, Project updatedProject)
        {
            var existingProject = projects.Find(p => p.Id == id);

            if (existingProject == null)
            {
                return NotFound();
            }

            existingProject.Nombre = updatedProject.Nombre;

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
