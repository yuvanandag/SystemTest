using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Model;
using Users.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Users.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly AppDBContext context = null;
        public UserRepository(AppDBContext dbContext)
        {
            context = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        public async Task<User> InsertUser(User user)
        {
            try
            {
                await context.Users.AddAsync(user);
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<User>> InsertUserList(List<User> userList)
        {
            await context.Users.AddRangeAsync(userList);
            return userList;
        }
    }
}
