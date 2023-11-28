using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TODOLIST.Enums;

namespace TODOLIST.Data.Entites
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string UserType { get; set; } = nameof(UserRoleEnum.Programer); //para usar el nombre de la propiedad del enum
        public bool State { get; set; } = true;
    }
}