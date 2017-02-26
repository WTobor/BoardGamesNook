using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GamerRepository : IGamerRepository
    {
        private readonly List<Gamer> _gamers = new List<Gamer>();

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
                _gamers.Remove(gamer);
        }
    }
}