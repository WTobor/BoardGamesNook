using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;
using System.Collections.Generic;

namespace BoardGamesNook.Services
{
    public class GamerBoardGameService : IGamerBoardGameService
    {
        private readonly IGamerBoardGameRepository _gamerBoardGameRepository;

        public GamerBoardGameService(IGamerBoardGameRepository gamerBoardGameRepository)
        {
            _gamerBoardGameRepository = gamerBoardGameRepository;
        }

        public GamerBoardGame Get(int id)
        {
            return _gamerBoardGameRepository.Get(id);
        }

        public IEnumerable<GamerBoardGame> GetAll()
        {
            return _gamerBoardGameRepository.GetAll();
        }

        public IEnumerable<GamerBoardGame> GetAllByGamerNick(string gamerNick)
        {
            return _gamerBoardGameRepository.GetAllByGamerNick(gamerNick);
        }

        public void Add(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGameRepository.Add(gamerBoardGame);
        }

        public void Edit(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGameRepository.Edit(gamerBoardGame);
        }

        public void Delete(int id)
        {
            _gamerBoardGameRepository.Delete(id);
        }
    }
}