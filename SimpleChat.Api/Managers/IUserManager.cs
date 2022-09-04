using SimpleChat.Api.Models;

namespace SimpleChat.Api.Managers
{
    // Manages users
    public interface IUserManager
    {
        Task<User> CreateOrGetUser(string login);
    }
}