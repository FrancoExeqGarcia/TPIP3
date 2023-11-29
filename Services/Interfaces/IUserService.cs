using System.Collections.Generic;
using System.Threading.Tasks;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;

namespace TODOLIST.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(int userId, User user);
        Task DeleteUserAsync(int userId);
        BaseResponse ValidateUser(string email, string password);
        UserDto? GetUserByEmail(string email);


    }
}
