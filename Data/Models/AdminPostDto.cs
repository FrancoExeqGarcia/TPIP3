using System.ComponentModel.DataAnnotations;

namespace TODOLIST.Data.Models
{
    public class AdminPostDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
