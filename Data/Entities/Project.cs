using System.ComponentModel.DataAnnotations;

namespace TODOLIST.Data.Entities
{
    public class Project
    {
        [Key]
        [Required]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
