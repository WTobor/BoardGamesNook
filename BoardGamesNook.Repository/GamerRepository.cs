using System;
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

        public Gamer GetGamer(string id)
        {
            return _gamers.FirstOrDefault(x => x.Id == id);
        }

        public Gamer GetGamerByEmail(string userEmail)
        {
            return _gamers.FirstOrDefault(x => x.Email == userEmail);
        }

        public Gamer GetGamerByNick(string userNick)
        {
            return _gamers.FirstOrDefault(x => x.Nick == userNick);
        }

        public bool NickExists(string nick)
        {
            return _gamers.Select(x => x.Nick).Contains(nick);
        }

        public IEnumerable<Gamer> GetAllGamers()
        {
            return _gamers;
        }

        public void AddGamer(Gamer gamer)
        {
            _gamers.Add(gamer);
        }

        public void EditGamer(Gamer gamer)
        {
            var dbGamer = _gamers.FirstOrDefault(x => x.Id == gamer.Id);
            if (dbGamer != null)
            {
                dbGamer.Name = gamer.Name;
                dbGamer.Surname = gamer.Surname;
                dbGamer.Age = gamer.Age;
                dbGamer.City = gamer.City;
                dbGamer.Street = gamer.Street;
                dbGamer.ModifiedDate = DateTimeOffset.Now;
            }
        }

        public void DeactivateGamer(string id)
        {
            var gamer = _gamers.FirstOrDefault(x => x.Id == id);
            if (gamer != null)
            {
                gamer.Active = false;
            }
        }
    }
}