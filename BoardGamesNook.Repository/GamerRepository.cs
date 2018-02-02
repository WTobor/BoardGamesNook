using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GamerRepository : IGamerRepository
    {
        private readonly List<Gamer> _gamers = GamerGenerator.Gamers;

        public Gamer Get(string id)
        {
            return _gamers.FirstOrDefault(x => x.Id == id);
        }

        public Gamer GetByEmail(string userEmail)
        {
            return _gamers.FirstOrDefault(x => x.Email == userEmail);
        }

        public Gamer GetByNickname(string userNickname)
        {
            return _gamers.FirstOrDefault(x => x.Nickname == userNickname);
        }

        public bool NicknameExists(string nickname)
        {
            return _gamers.Select(x => x.Nickname).Contains(nickname);
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

        public void Deactivate(string id)
        {
            var gamer = _gamers.FirstOrDefault(x => x.Id == id);
            if (gamer != null)
            {
                gamer.Active = false;
                gamer.ModifiedDate = DateTimeOffset.Now;
            }
        }
    }
}