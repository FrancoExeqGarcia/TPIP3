using System.ComponentModel.DataAnnotations;

namespace TODOLIST.Data.Entites
{
    public class Administrator : User

    {
        public string Role { get; set; } = "admin";

    }
}
