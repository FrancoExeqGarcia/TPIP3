using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entities;
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

        [HttpPut("{id}")]
        public ActionResult<ToDo> Put(int id, ToDo updatedToDo)
        {
            var existingToDo = _todoService.UpdateTodo(id, updatedToDo);

            if (existingToDo == null)
            {
                return NotFound();
            }

            return Ok(existingToDo);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _todoService.DeleteTodo(id);
            return NoContent();
        }
    }
}
