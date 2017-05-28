using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    internal interface IUserService
    {
        User GetUser();

        void SetUser(User user);
    }
}