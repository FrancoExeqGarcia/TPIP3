using System.ComponentModel.DataAnnotations;

namespace TODOLIST.Data.Entites
{
    public class Project 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description {  get; set; } 
    }
}
