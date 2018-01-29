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

        public Gamer GetGamerByNickname(string userNickname)
        {
            return _gamers.FirstOrDefault(x => x.Nickname == userNickname);
        }

        public bool NicknameExists(string nickname)
        {
            return _gamers.Select(x => x.Nickname).Contains(nickname);
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