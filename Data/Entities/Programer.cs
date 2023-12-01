namespace TODOLIST.Data.Entities
{
    public class Programer : User
    {
        public ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();
    }
}
