using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TODOLIST.Data.Entities;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramerController : ControllerBase
    {
        private List<User> users = new List<User>();

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = users.Find(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, User updatedUser)
        {
            var existingUser = users.Find(u => u.UserId == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.UserName = updatedUser.UserName;

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = users.Find(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            users.Remove(user);

            return NoContent();
        }
    }
}
