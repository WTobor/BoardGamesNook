using System.Collections.Generic;
using System.Linq;
using BoardGameGeekIntegration;
using BoardGameGeekIntegration.Models;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;

        public BoardGameService(IBoardGameRepository boardGameRepository)
        {
            _boardGameRepository = boardGameRepository;
        }

        public BoardGame Get(int id)
        {
            return _boardGameRepository.GetGamerBoardGame(id);
        }

        public IEnumerable<BoardGame> GetAllGamerBoardGames()
        {
            return _boardGameRepository.GetAllGamerBoardGames();
        }

        public List<SimilarBoardGame> AddOrGetSimilar(string name)
        {
            var boardGameId = BGGBoardGame.GetBoardGameId(name);
            if (boardGameId != 0)
            {
                var boardGame = BGGBoardGame.GetBoardGameById(boardGameId);
                boardGame.Id = GetAllGamerBoardGames().Select(x => x.Id).LastOrDefault() + 1;
                Add(boardGame);
                return new List<SimilarBoardGame>();
            }

            var similarBoardGameList = BGGBoardGame.GetSimilarBoardGameList(name).ToList();
            return similarBoardGameList.Take(10).ToList();
        }

        public void Add(BoardGame boardGame)
        {
            boardGame.Id = GetAllGamerBoardGames().Select(x => x.Id).LastOrDefault() + 1;
            _boardGameRepository.Add(boardGame);
        }

        public void Edit(BoardGame boardGame)
        {
            _boardGameRepository.EditGamerBoardGame(boardGame);
        }

        public void Delete(int id)
        {
            _boardGameRepository.DeleteGamerBoardGame(id);
        }

        public IEnumerable<BoardGame> GetAllByIds(IEnumerable<int> tableBoardGameIdList)
        {
            var result = new List<BoardGame>();
            foreach (var boardGameId in tableBoardGameIdList)
            {
                var boardGame = Get(boardGameId);
                if (boardGame != null)
                    result.Add(boardGame);
            }

            return result;
        }
    }
}