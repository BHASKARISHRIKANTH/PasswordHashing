using PasswordHashing.Models;

namespace PasswordHashing.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByUserName(string userName);
    }
}
