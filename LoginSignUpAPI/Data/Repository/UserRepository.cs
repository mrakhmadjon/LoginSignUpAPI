using LoginSignUpAPI.Data.Contexts;
using LoginSignUpAPI.Data.IRepository;
using LoginSignUpAPI.Extensions;
using LoginSignUpAPI.Models.Common;
using LoginSignUpAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoginSignUpAPI.Data.Repository
{
#pragma warning disable
    public class UserRepository : IUserRepository
    {
        private UserDbContext _userDb;
        private DbSet<UserModel> _users;
        public UserRepository(UserDbContext userDb)
        {
            _userDb = userDb;   
            _users = userDb.Set<UserModel>();

        }

        public async Task<bool> DeleteAsync(Expression<Func<UserModel, bool>> expression)
        {
            var entry = await _users.FirstOrDefaultAsync(expression);
            if (entry is null)
                return false;

            _users.Remove(entry);
            await _userDb.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return _users;
        }

        public async Task<UserModel> GetAsync(int id)
        {
            return await _users.FindAsync(id);
        }

        public async Task<UserModel> LoginAsync(string email, string password)
        {
            string hashedPass = password.ToHash();
           var user = await _users.FirstOrDefaultAsync(p => p.Email == email && p.Password == hashedPass);
          return user;
        }

        public async Task<UserModel> SignUpAsync(UserViewModel user)
        {
            UserModel user1 = new UserModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password.ToHash()
            };
             var entry = await _users.AddAsync(user1);
             await  _userDb.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<UserModel> UpdateAsync(UserModel user)
        {
            user.Password = user.Password.ToHash();
            var entry = _users.Update(user);
            await _userDb.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
