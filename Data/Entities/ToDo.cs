using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TODOLIST.Data.Entities
{
    public class ToDo
    {
        [Key]
        [Required]
        public int ToDoId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RealtedProject { get; set; }
        public Programer Programer { get; set; }

    }
}
