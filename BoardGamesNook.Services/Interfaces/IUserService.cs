using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    interface IUserService
    {
        User Get(int id);

        IEnumerable<User> GetAll();

        void Add(User user);

        void Edit(User user);

        void Delete(int id);
    }
}
