using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;
using System.Collections.Generic;

namespace BoardGamesNook.Services
{
    public class GamerService : IGamerService
    {
        private readonly IGamerRepository _gamerRepository;

        public GamerService(IGamerRepository gamerRepository)
        {
            _gamerRepository = gamerRepository;
        }

        public Gamer Get(string id)
        {
            return _gamerRepository.GetGamer(id);
        }

        public Gamer GetGamerByEmail(string userEmail)
        {
            return _gamerRepository.GetGamerByEmail(userEmail);
        }

        public Gamer GetByNick(string userNick)
        {
            return _gamerRepository.GetGamerByNick(userNick);
        }

        public bool NickExists(string nick)
        {
            return _gamerRepository.NickExists(nick);
        }

        public IEnumerable<Gamer> GetAllGamers()
        {
            return _gamerRepository.GetAllGamers();
        }

        public void AddGamer(Gamer gamer)
        {
            _gamerRepository.AddGamer(gamer);
        }

        public void EditGamer(Gamer gamer)
        {
            _gamerRepository.EditGamer(gamer);
        }

        public void DeactivateGamer(string id)
        {
            _gamerRepository.DeactivateGamer(id);
        }
    }
}