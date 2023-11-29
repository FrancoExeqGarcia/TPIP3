namespace TODOLIST.Data.Entities
{
    public class Programer : User
    {
        public string Project { get; set; }
        public string Name { get; set; }
        public List<ToDo> ToDo { get; set; }

    }
}
