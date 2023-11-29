namespace TODOLIST.Data.Entities
{
    public class Programer : User
    {
        public List<ToDo> ToDos { get; set; }
    }
}
