using System.Collections.Generic;
using System.Threading.Tasks;
using TODOLIST.Data.Entites;

namespace TODOLIST.Services.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            // Implementar lógica para obtener todos los usuarios
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            // Implementar lógica para obtener un usuario por ID
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task CreateUserAsync(User user)
        {
            // Implementar lógica para crear un nuevo usuario
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateUserAsync(int userId, User user)
        {
            // Implementar lógica para actualizar un usuario
            var existingUser = await _userRepository.GetByIdAsync(userId);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;

                await _userRepository.UpdateAsync(existingUser);
            }
            // Puedes manejar el caso si el usuario no existe
        }

        public async Task DeleteUserAsync(int userId)
        {
            // Implementar lógica para eliminar un usuario
            var userToDelete = await _userRepository.GetByIdAsync(userId);

            if (userToDelete != null)
            {
                userToDelete.State = false;
                await _userRepository.UpdateAsync(userToDelete);
            }
            // Puedes manejar el caso si el usuario no existe
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            // Implementar lógica para obtener un usuario por email
            return await _userRepository.GetFirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<BaseResponse> UserValidationAsync(string email, string password)
        {
            // Implementar lógica para la validación de usuario
            BaseResponse response = new BaseResponse();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                response.Result = false;
                response.Message = "Por favor, ingrese email y contraseña";
                return response;
            }

            User? userForLogin = await _userRepository.GetFirstOrDefaultAsync(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "Inicio de sesión exitoso";
                }
                else
                {
                    response.Result = false;
                    response.Message = "Contraseña incorrecta";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "Email incorrecto";
            }
            return response;
        }
    }
}
