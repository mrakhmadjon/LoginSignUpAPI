using LoginSignUpAPI.Data.IRepository;
using LoginSignUpAPI.Models.Common;
using LoginSignUpAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginSignUpAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]

        public async Task<IActionResult> SignUp([FromForm]UserViewModel user)
        {
            return Ok( await _userRepository.SignUpAsync(user));
        }

        [HttpGet]
        public async Task<IActionResult> Login( string email,   string password)
        {
            return Ok(await _userRepository.LoginAsync(email, password));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]  UserModel user)
        {
            return Ok(await _userRepository.UpdateAsync(user));
        }

        [HttpGet("{id}")]
       // [AllowAnonymous]
       public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userRepository.GetAsync(id));
        }


        [HttpGet]
        [Route("All")]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync());
        }
    }
}
