using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;
using TODOLIST.Services.Implementations;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IToDoService _todoService;

        public TodoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            var todos = _todoService.GetAllToDos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int id)
        {
            var todo = _todoService.GetTodoById(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }
        [HttpPost]
        public IActionResult CreateProject([FromBody] ToDoUpdateDto toDoCreateDto)
        {
            var toDo = new ToDo
            {
                Name = toDoCreateDto.Name,
                StartDate = toDoCreateDto.StartDate,
                EndDate = toDoCreateDto.EndDate,
            };

            try
            {
                var createdToDo = _todoService.CreateTodo(toDo);
                return CreatedAtAction(nameof(Get), new { id = createdToDo.ProjectId }, createdToDo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateToDo(int todoId,[FromBody] ToDoUpdateDto toDoUpdateDto)
        {
            var updatedToDo = new ToDo
            {
                Name = toDoUpdateDto.Name,
                StartDate = toDoUpdateDto.StartDate,
                EndDate = toDoUpdateDto.EndDate,
            };

            try
            {
                var result = _todoService.UpdateTodo(todoId, updatedToDo);
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
        public IActionResult DeleteToDo(int todoId)
        {
            try
            {
                _todoService.DeleteTodo(todoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
