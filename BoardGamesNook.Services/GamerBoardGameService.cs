using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class GamerBoardGameService : IGamerBoardGameService
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IGamerBoardGameRepository _gamerBoardGameRepository;

        public GamerBoardGameService(IGamerBoardGameRepository gamerBoardGameRepository,
            IBoardGameService boardGameService)
        {
            _gamerBoardGameRepository = gamerBoardGameRepository;
            _boardGameService = boardGameService;
        }

        public GamerBoardGame GetGamerBoardGame(int id)
        {
            return _gamerBoardGameRepository.Get(id);
        }

        public IEnumerable<BoardGame> GetGamerAvailableBoardGameList(string nickname)
        {
            var availableBoardGameList = _boardGameService.GetAllGamerBoardGames();
            var gamerBoardGameList = GetAllGamerBoardGamesByGamerNickname(nickname);
            var gamerAvailableBoardGameList = availableBoardGameList
                .Where(x => gamerBoardGameList.All(y => y.BoardGameId != x.Id)).ToList();
            return gamerAvailableBoardGameList;
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGames()
        {
            return _gamerBoardGameRepository.GetAll();
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNickname(string gamerNickname)
        {
            return _gamerBoardGameRepository.GetAllByGamerNickname(gamerNickname);
        }

        public void Add(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGameRepository.Add(gamerBoardGame);
        }

        public void EditGamerBoardGame(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGameRepository.Edit(gamerBoardGame);
        }

        public void DeactivateGamerBoardGame(int id)
        {
            _gamerBoardGameRepository.Deactivate(id);
        }
    }
}