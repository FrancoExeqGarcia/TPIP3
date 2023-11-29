using System.Collections.Generic;
using System.Threading.Tasks;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TODOLIST.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetUserByEmail(string email);
        public bool CheckIfUserExists(string userEmail);
        public BaseResponse ValidateUser(string email, string password);
        public int CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);
        public List<User> GetUsersByRole(string role);


    }
}
