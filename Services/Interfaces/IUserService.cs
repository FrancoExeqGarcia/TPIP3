using ErrorOr;
using System.Collections.Generic;
using System.Threading.Tasks;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TODOLIST.Services.Interfaces
{
    public interface IUserService
    {
        public bool CheckIfUserExists(string userEmail);
        public BaseResponse ValidateUser(string email, string password);
        public ErrorOr<int> CreateUser(User user);
        public ErrorOr<Deleted> DeleteUser(int userId);
        List<User> GetAllUsers();
        public User GetUserById(int userId);
        public User GetUserByEmail(string email);
        User UpdateUser(User user);

    }
}
