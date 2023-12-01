using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TODOLIST.Enums;

namespace TODOLIST.Data.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        [Required]
        public string UserName { get; set; } = "";
        public string UserType { get; set; } = nameof(UserRoleEnum.Programer); //para usar el nombre de la propiedad del enum
        public UserRoleEnum Role { get; set; } = UserRoleEnum.Programer; //Defecto al minimo
        public bool State { get; set; } = true;
    }
}