using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoardGamesNook.Services
{
    public class GamerBoardGameService : IGamerBoardGameService
    {
        private readonly IGamerBoardGameRepository _gamerBoardGameRepository;
        private readonly IBoardGameService _boardGameService;

        public GamerBoardGameService(IGamerBoardGameRepository gamerBoardGameRepository, IBoardGameService boardGameService)
        {
            _gamerBoardGameRepository = gamerBoardGameRepository;
            _boardGameService = boardGameService;
        }

        public GamerBoardGame GetGamerBoardGame(int id)
        {
            return _gamerBoardGameRepository.GetGamerBoardGame(id);
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
            return _gamerBoardGameRepository.GetAllGamerBoardGames();
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNickname(string gamerNickname)
        {
            return _gamerBoardGameRepository.GetAllGamerBoardGamesByGamerNickname(gamerNickname);
        }

        public void Add(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGameRepository.AddGamerBoardGame(gamerBoardGame);
        }

        public void EditGamerBoardGame(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGameRepository.EditGamerBoardGame(gamerBoardGame);
        }

        public void DeleteGamerBoardGame(int id)
        {
            _gamerBoardGameRepository.DeleteGamerBoardGame(id);
        }
    }
}