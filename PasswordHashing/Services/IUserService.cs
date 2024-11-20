using PasswordHashing.Dtos;

namespace PasswordHashing.Services
{
    public interface IUserService
    {
        void RegisterUser(UserDto userDto);
        bool LoginUser(LoginDto loginDto);
    }
}
