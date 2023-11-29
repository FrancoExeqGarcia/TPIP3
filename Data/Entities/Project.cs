using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("UserId")]
        public Admin Admin { get; set; }
        public int UserId { get; set; }
    }
}
