using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHashing.Dtos;
using PasswordHashing.Services;

namespace PasswordHashing.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public IActionResult CreateUser(UserDto userDto)
        {
            _userService.RegisterUser(userDto);
            return Ok("User created successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            bool isLoggedIn = _userService.LoginUser(loginDto);

            if (!isLoggedIn)
                return BadRequest("Invalid credentials");

            return Ok("Login successful");
        }
    }
}

