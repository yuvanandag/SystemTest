using Microsoft.EntityFrameworkCore;
using Users.Model;

namespace Users.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
