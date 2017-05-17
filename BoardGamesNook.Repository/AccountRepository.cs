using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private List<User> _users = UserGenerator.users;

        public bool Login(string login, string password)
        {
            return _users.Where(x => x.Login == login && x.Password == password && x.Active && x.IsConfirmed).FirstOrDefault() != null;
        }

        public bool IsLoginAllowed(string login)
        {
            bool loginIsAllowed = _users.Where(x => x.Login == login).FirstOrDefault() == null;
            return loginIsAllowed;
        }
    }
}
