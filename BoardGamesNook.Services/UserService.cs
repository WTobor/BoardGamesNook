using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class UserService : IUserService
    {
        public User _loggedUser;

        public User GetUser()
        {
            return _loggedUser;
        }

        public void SetUser(User user)
        {
            _loggedUser = user;
        }
    }
}