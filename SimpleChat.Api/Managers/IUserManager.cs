using SimpleChat.Api.Models;

namespace SimpleChat.Api.Managers
{
    // Manages users
    public interface IUserManager
    {
        Task<User> CreateUser(string login);

        Task<User?> GetUser(string login);
    }
}