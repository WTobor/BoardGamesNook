using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GameResultRepository : IGameResultRepository
    {
        private readonly List<GameResult> _gameResults = GameResultGenerator.gameResults;

        public GameResult GetGameResult(int id)
        {
            return _gameResults.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameResult> GetAllGameResults()
        {
            return _gameResults;
        }

        public IEnumerable<GameResult> GetAllGameResultsByTableId(int tableId)
        {
            return _gameResults.Where(x => x.GameTableId == tableId).ToList();
        }

        public IEnumerable<GameResult> GetAllGameResultsByGamerNickname(string nickname)
        {
            return _gameResults.Where(x => x.Gamer != null && x.Gamer.Nickname == nickname).ToList();
        }

        public void AddGameResult(GameResult gameResult)
        {
            _gameResults.Add(gameResult);
        }

        public void AddGameResults(List<GameResult> gameResults)
        {
            foreach (var gameResult in gameResults)
            {
                _gameResults.Add(gameResult);
            }
        }

        public void EditGameResult(GameResult gameResult)
        {
            gameResult.ModifiedDate = DateTimeOffset.Now;
        }

        public void DeleteGameResult(int id)
        {
            var gameResult = _gameResults.FirstOrDefault(x => x.Id == id);
            if (gameResult != null)
                _gameResults.Remove(gameResult);
        }
    }
}