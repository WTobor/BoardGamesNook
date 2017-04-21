using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoardGamesNook.Repository
{
    public class GamerRepository : IGamerRepository
    {
        public static List<Gamer> _gamers = new List<Gamer>()
        {
            new Gamer()
            {
                Id = 1,
                Active = true,
                Age = 5,
                Nick = "testNick",
                Name = "testName",
                Surname = "testSurname",
                City = "Wrocław",
                Street = "tmp"
            },
            new Gamer()
            {
                Id = 2,
                Active = true,
                Age = 51,
                Nick = "testNick1",
                Name = "testName1",
                Surname = "testSurname1",
                City = "Wrocław1",
                Street = "tmp1"
            }
        };

        public Gamer Get(int id)
        {
            return _gamers.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Gamer> GetAll()
        {
            return _gamers;
        }

        public void Add(Gamer gamer)
        {
            _gamers.Add(gamer);
        }

        public void Edit(Gamer gamer)
        {
            var oldGamer = _gamers.Where(x => x.Id == gamer.Id).FirstOrDefault();
            if (oldGamer != null)
            {
                _gamers.Remove(oldGamer);
                _gamers.Add(gamer);
            }
        }

        public void Delete(int id)
        {
            var gamer = _gamers.Where(x => x.Id == id).FirstOrDefault();
            if (gamer != null)
            {
                _gamers.Remove(gamer);
            }
        }
    }
}