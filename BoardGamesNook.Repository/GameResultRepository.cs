using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GameResultRepository : IGameResultRepository
    {
        private List<GameResult> _gameResults = GameResultGenerator.gameResults;

        public GameResult Get(int id)
        {
            return _gameResults.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<GameResult> GetAll()
        {
            return _gameResults;
        }

        public IEnumerable<GameResult> GetAllByTableId(int tableId)
        {
            return _gameResults.Where(x => x.GameTableId == tableId).ToList();
        }

        public IEnumerable<GameResult> GetAllByGamerNick(string nick)
        {
            return _gameResults.Where(x => x.Gamer != null && x.Gamer.Nick == nick).ToList();
        }

        public void Add(GameResult gameResult)
        {
            _gameResults.Add(gameResult);
        }

        public void Edit(GameResult gameResult)
        {
            var oldGamer = _gameResults.Where(x => x.Id == gameResult.Id).FirstOrDefault();
            if (oldGamer != null)
            {
                _gameResults.Remove(oldGamer);
                _gameResults.Add(gameResult);
            }
        }

        public void Delete(int id)
        {
            var gameResult = _gameResults.Where(x => x.Id == id).FirstOrDefault();
            if (gameResult != null)
            {
                _gameResults.Remove(gameResult);
            }
        }
    }
}