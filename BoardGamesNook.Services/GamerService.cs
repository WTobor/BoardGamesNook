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

        public Gamer GetGamer(string id)
        {
            return _gamerRepository.GetGamer(id);
        }

        public Gamer GetGamerByEmail(string userEmail)
        {
            return _gamerRepository.GetGamerByEmail(userEmail);
        }

        public Gamer GetGamerBoardGameByNickname(string userNickname)
        {
            return _gamerRepository.GetGamerByNickname(userNickname);
        }

        public bool NicknameExists(string nickname)
        {
            return _gamerRepository.NicknameExists(nickname);
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