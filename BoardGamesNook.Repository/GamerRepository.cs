using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GamerRepository : IGamerRepository
    {
        private readonly List<Gamer> _gamers = GamerGenerator.gamers;

        public Gamer Get(string id)
        {
            return _gamers.FirstOrDefault(x => x.Id == id);
        }

        public Gamer GetByEmail(string userEmail)
        {
            return _gamers.FirstOrDefault(x => x.Email == userEmail);
        }

        public Gamer GetByNick(string userNick)
        {
            return _gamers.FirstOrDefault(x => x.Nick == userNick);
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
            var oldGamer = _gamers.FirstOrDefault(x => x.Id == gamer.Id);
            if (oldGamer != null)
            {
                _gamers.Remove(oldGamer);
                _gamers.Add(gamer);
            }
        }

        public void Deactivate(string id)
        {
            var gamer = _gamers.FirstOrDefault(x => x.Id == id);
            if (gamer != null)
                gamer.Active = false;
        }
    }
}