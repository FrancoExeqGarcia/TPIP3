using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entities;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public ActionResult<int> CreateProject([FromBody] Project project)
        {
            var projectId = _projectService.CreateProject(project);
            return Ok(projectId);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _projectService.UpdateProject(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
            return NoContent();
        }
    }
}
