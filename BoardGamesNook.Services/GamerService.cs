using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class GamerService : IGamerService
    {
        private readonly IGamerRepository _gamerRepository;

        public GamerService(IGamerRepository gamerRepository)
        {
            _gamerRepository = gamerRepository;
        }

        public Gamer GetGamer(string id)
        {
            return _gamerRepository.Get(id);
        }

        public Gamer GetGamerByEmail(string userEmail)
        {
            return _gamerRepository.GetByEmail(userEmail);
        }

        public Gamer GetGamerBoardGameByNickname(string userNickname)
        {
            return _gamerRepository.GetByNickname(userNickname);
        }

        public bool NicknameExists(string nickname)
        {
            return _gamerRepository.NicknameExists(nickname);
        }

        public IEnumerable<Gamer> GetAllGamers()
        {
            return _gamerRepository.GetAll();
        }

        public void AddGamer(Gamer gamer)
        {
            _gamerRepository.Add(gamer);
        }

        public void EditGamer(Gamer gamer)
        {
            _gamerRepository.Edit(gamer);
        }

        public void DeactivateGamer(string id)
        {
            _gamerRepository.Deactivate(id);
        }
    }
}