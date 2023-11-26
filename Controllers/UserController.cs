using Microsoft.AspNetCore.Mvc;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = users.Find(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, User updatedUser)
        {
            var existingUser = users.Find(u => u.Id == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Nombre = updatedUser.Nombre;

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = users.Find(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            users.Remove(user);

            return NoContent();
        }
    }
}
}
