using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private List<Data.Entities.ToDo> todos = new List<Data.Entities.ToDo>();

        [HttpGet]
        public ActionResult<IEnumerable<Data.Entities.ToDo>> Get()
        {
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public ActionResult<Data.Entities.ToDo> Get(int id)
        {
            var todo = todos.Find(t => t.ToDoId == id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public ActionResult<Data.Entities.ToDo> Put(int id, Data.Entities.ToDo updatedToDo)
        {
            var existingToDo = todos.Find(t => t.ToDoId == id);

            if (existingToDo == null)
            {
                return NotFound();
            }

            existingToDo.Name = updatedToDo.Name;
            existingToDo.StartDate = updatedToDo.StartDate;
            existingToDo.EndDate = updatedToDo.EndDate;

            return Ok(existingToDo);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todo = todos.Find(t => t.ToDoId == id);

            if (todo == null)
            {
                return NotFound();
            }

            todos.Remove(todo);

            return NoContent();
        }
    }
}
