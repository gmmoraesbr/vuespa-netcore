using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }
}
