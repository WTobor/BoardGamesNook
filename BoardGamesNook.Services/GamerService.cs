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
            return _gamerRepository.Get(id);
        }

        public Gamer GetByEmail(string userEmail)
        {
            return _gamerRepository.GetByEmail(userEmail);
        }

        public Gamer GetByNick(string userNick)
        {
            return _gamerRepository.GetByNick(userNick);
        }

        public bool NickExists(string nick)
        {
            return _gamerRepository.NickExists(nick);
        }

        public IEnumerable<Gamer> GetAll()
        {
            return _gamerRepository.GetAll();
        }

        public void Add(Gamer gamer)
        {
            _gamerRepository.Add(gamer);
        }

        public void Edit(Gamer gamer)
        {
            _gamerRepository.Edit(gamer);
        }

        public void Delete(string id)
        {
            _gamerRepository.Delete(id);
        }
    }
}