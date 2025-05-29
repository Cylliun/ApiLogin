using ApiLogin.Dto;
using ApiLogin.Models;
using ApiLogin.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUserDatails(int id)
        {
            var user = await _userRepository.GetUserDatails(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> PostRegister(RegisterUserDto registerUserDto)
        {
            var user = await _userRepository.PostRegister(registerUserDto);

            if (user == null) 
            { 
                return NotFound();
            }

            return Ok(user);

        }

        [HttpPost]
        public async Task<ActionResult<string>> PostLogin(UserLoginDto userLoginDto)
        {
            var user = await _userRepository.PostLogin(userLoginDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

    }
}
