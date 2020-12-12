using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Model;

namespace Users.Repository
{
    public interface IUserRepository
    {
        Task<User> InsertUser(User user);
        Task<List<User>> InsertUserList(List<User> userList);
        Task<List<User>> GetUsers();
    }
}
