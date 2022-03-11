using LoginSignUpAPI.Models.Common;
using LoginSignUpAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginSignUpAPI.Data.IRepository
{
    public interface IUserRepository
    {
        Task<UserModel> SignUpAsync(UserViewModel user); 
        Task<UserModel> LoginAsync(string email, string password);

        Task<UserModel> UpdateAsync(UserModel user);

        Task<IEnumerable<UserModel>> GetAllAsync();

        Task<UserModel> GetAsync(int id);

    }
}
