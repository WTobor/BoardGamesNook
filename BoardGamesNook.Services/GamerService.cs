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

        public Gamer Get(int id)
        {
            return _gamerRepository.Get(id);
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

        public void Delete(int id)
        {
            _gamerRepository.Delete(id);
        }
    }
}