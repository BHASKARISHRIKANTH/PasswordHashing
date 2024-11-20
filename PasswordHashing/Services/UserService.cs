using PasswordHashing.Dtos;
using PasswordHashing.Models;
using PasswordHashing.Repositories;

namespace PasswordHashing.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool LoginUser(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByUserName(loginDto.UserName);

            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
        }

        public void RegisterUser(UserDto userDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = userDto.UserName,
                PasswordHash = passwordHash,
                Email = userDto.Email
            };

            _userRepository.AddUser(user);
        }
    }
}
