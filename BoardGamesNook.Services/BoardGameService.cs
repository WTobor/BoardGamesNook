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
            return _boardGameRepository.Get(id);
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _boardGameRepository.GetAll();
        }

        public List<SimilarBoardGame> AddOrGetSimilar(string name)
        {
            var boardGameId = BGGBoardGame.GetBoardGameId(name);
            if (boardGameId != 0)
            {
                var boardGame = BGGBoardGame.GetBoardGameById(boardGameId);
                if (!CheckIfExists(name))
                    Add(boardGame);
                return new List<SimilarBoardGame>();
            }

            var similarBoardGameList = BGGBoardGame.GetSimilarBoardGameList(name).ToList();
            return similarBoardGameList.Take(10).ToList();
        }

        public BoardGame GetBGGBoardGameById(int id)
        {
            return BGGBoardGame.GetBoardGameById(id);
        }

        public void Add(BoardGame boardGame)
        {
            boardGame.Id = GetAll().Select(x => x.Id).LastOrDefault() + 1;
            _boardGameRepository.Add(boardGame);
        }

        public bool CheckIfExists(string name)
        {
            return _boardGameRepository.CheckIfExists(name);
        }

        public void Edit(BoardGame boardGame)
        {
            _boardGameRepository.Edit(boardGame);
        }

        public void DeactivateBoardGame(int id)
        {
            _boardGameRepository.Deactivate(id);
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