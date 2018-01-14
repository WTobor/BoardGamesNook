using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class GameResultService : IGameResultService
    {
        private readonly IGameResultRepository _gameResultRepository;

        public GameResultService(IGameResultRepository gameResultRepository)
        {
            _gameResultRepository = gameResultRepository;
        }

        public GameResult GetGameResult(int id)
        {
            return _gameResultRepository.GetGameResult(id);
        }

        public IEnumerable<GameResult> GetAllGameResults()
        {
            return _gameResultRepository.GetAllGameResults();
        }

        public IEnumerable<GameResult> GetAllGameResultsByTableId(int id)
        {
            return _gameResultRepository.GetAllGameResultsByTableId(id);
        }

        public IEnumerable<GameResult> GetAllByGamerNick(string nick)
        {
            return _gameResultRepository.GetAllGameResultsByGamerNick(nick);
        }

        public void AddGameResult(GameResult gameResult)
        {
            _gameResultRepository.AddGameResult(gameResult);
        }

        public void Edit(GameResult gameResult)
        {
            _gameResultRepository.EditGameResult(gameResult);
        }

        public void DeleteGameResult(int id)
        {
            _gameResultRepository.DeleteGameResult(id);
        }
    }
}