using Microsoft.AspNetCore.Mvc;

namespace TODOLIST.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController
    {

        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return Ok(items);
        }
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = items.Find(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public ActionResult<Item> Put(int id, Item updatedItem)
        {
            var existingItem = items.Find(i => i.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Nombre = updatedItem.Nombre;

            return Ok(existingItem);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = items.Find(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            items.Remove(item);

            return NoContent();
        }
    }
}
}
