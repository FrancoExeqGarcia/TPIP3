using System.Collections.Generic;
using System.Threading.Tasks;
using TODOLIST.Data.Entities;

namespace TODOLIST.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(int userId, User user);
        Task DeleteUserAsync(int userId);
    }
}
