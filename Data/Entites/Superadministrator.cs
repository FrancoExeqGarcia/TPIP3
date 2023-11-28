namespace TODOLIST.Data.Entites
{
    public class SuperAdministrator : Administrator
    {
        public string Role { get; set; } = "superadmin";
        public virtual void AddUser(User user)
        {
            // Lógica para agregar un usuario
        }

        public virtual void UpdateUser(User user)
        {
            // Lógica para actualizar un usuario
        }

        public virtual void DeleteUser(User user)
        {
            // Lógica para eliminar un usuario
        }
    }
}
