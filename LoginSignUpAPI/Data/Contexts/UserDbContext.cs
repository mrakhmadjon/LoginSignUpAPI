using LoginSignUpAPI.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace LoginSignUpAPI.Data.Contexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
    }
}
