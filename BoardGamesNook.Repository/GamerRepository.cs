using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Repository.Generators;

namespace BoardGamesNook.Repository
{
    public class GamerRepository : IGamerRepository
    {
        private List<Gamer> _gamers = GamerGenerator.gamers;

        public Gamer Get(string id)
        {
            return _gamers.Where(x => x.Id == id).FirstOrDefault();
        }

        public Gamer GetByEmail(string userEmail)
        {
            return _gamers.Where(x => x.Email == userEmail).FirstOrDefault();
        }

        public Gamer GetByNick(string userNick)
        {
            return _gamers.Where(x => x.Nick == userNick).FirstOrDefault();
        }

        public bool NickExists(string nick)
        {
            return _gamers.Select(x => x.Nick).Contains(nick);
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

        public void Delete(string id)
        {
            var gamer = _gamers.Where(x => x.Id == id).FirstOrDefault();
            if (gamer != null)
            {
                _gamers.Remove(gamer);
            }
        }
    }
}