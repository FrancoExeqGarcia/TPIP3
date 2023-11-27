using System.ComponentModel.DataAnnotations;

namespace TODOLIST.Data.Entites
{
    public class Administrator : User

    {
        [Key]
        [Required]
        public ICollection<ToDo> AssignedToDos { get; set; }



    }
}
