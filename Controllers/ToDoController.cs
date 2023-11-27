using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entites;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private List<ToDo> todos = new List<ToDo>();

        [HttpGet]
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int id)
        {
            var todo = todos.Find(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public ActionResult<ToDo> Put(int id, ToDo updatedToDo)
        {
            var existingToDo = todos.Find(t => t.Id == id);

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
            var todo = todos.Find(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            todos.Remove(todo);

            return NoContent();
        }
    }
}
