using Microsoft.EntityFrameworkCore;
using PasswordHashing.Models;

namespace PasswordHashing.Data
{
    public class UserDbContext:DbContext
    {
        public DbSet<User> Users {  get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        

    }
}
