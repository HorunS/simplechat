using SimpleChat.Api.Models;

namespace SimpleChat.Api.Managers
{
    // Manages users
    public interface IUserManager
    {
        Task<User> GetUser(string login);

        Task<User> CreateUser(string login);
    }
}