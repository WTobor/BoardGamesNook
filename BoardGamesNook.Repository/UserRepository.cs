using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = UserGenerator.users;

        public User Get(int id)
        {
            return _users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Edit(User user)
        {
            var oldUser = _users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (oldUser != null)
            {
                _users.Remove(oldUser);
                _users.Add(user);
            }
        }

        public void Delete(int id)
        {
            var user = _users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}