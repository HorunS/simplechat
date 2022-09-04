using SimpleChat.Api.Models;

namespace SimpleChat.Api.Managers
{
    // Manages users
    public interface IUserManager
    {
        Task<string> CreateUser(string login);

        Task<User?> GetUser(string token);
    }
}