using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;
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
        public IActionResult CreateProject([FromBody] ProjectCreateDto projectCreateDto)
        {
            var project = new Project
            {
                Name = projectCreateDto.Name,
                StartDate = projectCreateDto.StartDate,
                EndDate = projectCreateDto.EndDate,
                Description = projectCreateDto.Description
            };

            try
            {
                var createdProject = _projectService.CreateProject(project);
                return CreatedAtAction(nameof(GetProject), new { id = createdProject.ProjectId }, createdProject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int projectId, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            var updatedProject = new Project
            {
                Name = projectUpdateDto.Name,
                StartDate = projectUpdateDto.StartDate,
                EndDate = projectUpdateDto.EndDate,
                Description = projectUpdateDto.Description
            };

            try
            {
                var result = _projectService.UpdateProject(projectId, updatedProject);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                _projectService.DeleteProject(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
