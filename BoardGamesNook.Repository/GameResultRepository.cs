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
        private readonly List<GameResult> _gameResults = GameResultGenerator.GameResults;

        public GameResult Get(int id)
        {
            return _gameResults.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameResult> GetAll()
        {
            return _gameResults;
        }

        public IEnumerable<GameResult> GetAllByTableId(int tableId)
        {
            return _gameResults.Where(x => x.GameTableId == tableId).ToList();
        }

        public IEnumerable<GameResult> GetAllByGamerNickname(string nickname)
        {
            return _gameResults.Where(x => x.Gamer != null && x.Gamer.Nickname == nickname).ToList();
        }

        public void Add(GameResult gameResult)
        {
            _gameResults.Add(gameResult);
        }

        public void AddMany(List<GameResult> gameResults)
        {
            foreach (var gameResult in gameResults) _gameResults.Add(gameResult);
        }

        public void Edit(GameResult gameResult)
        {
            var dbGameResult = _gameResults.FirstOrDefault(x => x.Id == gameResult.Id);
            if (dbGameResult != null)
            {
                dbGameResult.Points = gameResult.Points;
                dbGameResult.Place = gameResult.Place;
                dbGameResult.ModifiedDate = DateTimeOffset.Now;
            }
            
        }

        public void Deactivate(int id)
        {
            var gameResult = _gameResults.FirstOrDefault(x => x.Id == id);
            if (gameResult != null)
            {
                gameResult.Active = false;
                gameResult.ModifiedDate = DateTimeOffset.Now;
            }
        }
    }
}