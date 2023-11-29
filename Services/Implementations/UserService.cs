using System.Collections.Generic;
using System.Threading.Tasks;
using TODOLIST.Data.Entities;
using TODOLIST.Services.Interfaces;
using TODOLIST.Data.Models;
using TODOLIST.Data;
using TODOLIST.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TODOLIST.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ToDoContext _toDoContext;

        public UserService(ToDoContext context)
        {
            _toDoContext = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            // Implementar lógica para obtener todos los usuarios
            return await _toDoContext.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            // Implementar lógica para obtener un usuario por ID
            return await _toDoContext.GetByIdAsync(userId);
        }

        public async Task CreateUserAsync(User user)
        {
            // Implementar lógica para crear un nuevo usuario
            await _toDoContext.CreateAsync(user);
        }

        public async Task UpdateUserAsync(int userId, User user)
        {
            // Implementar lógica para actualizar un usuario
            var existingUser = await _toDoContext.GetByIdAsync(userId);

            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;

                await _toDoContext.UpdateAsync(existingUser);
            }
            // Puedes manejar el caso si el usuario no existe
        }

        public async Task DeleteUserAsync(int userId)
        {
            // Implementar lógica para eliminar un usuario
            var userToDelete = await _toDoContext.GetByIdAsync(userId);

            if (userToDelete != null)
            {
                userToDelete.State = false;
                await _toDoContext.UpdateAsync(userToDelete);
            }
            // Puedes manejar el caso si el usuario no existe
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            // Implementar lógica para obtener un usuario por email
            return await _toDoContext.GetFirstOrDefaultAsync(u => u.Email == email);
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

            User? userForLogin = await _toDoContext.GetFirstOrDefaultAsync(u => u.Email == email);
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

        BaseResponse IUserService.ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        UserDto? IUserService.GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
