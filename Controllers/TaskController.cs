using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entites;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private List<Data.Entites.Task> todos = new List<Data.Entites.Task>();

        [HttpGet]
        public ActionResult<IEnumerable<Data.Entites.Task>> Get()
        {
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public ActionResult<Data.Entites.Task> Get(int id)
        {
            var todo = todos.Find(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public ActionResult<Data.Entites.Task> Put(int id, Data.Entites.Task updatedToDo)
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
