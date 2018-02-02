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
            return _gameResultRepository.Get(id);
        }

        public IEnumerable<GameResult> GetAllGameResults()
        {
            return _gameResultRepository.GetAll();
        }

        public IEnumerable<GameResult> GetAllGameResultsByTableId(int id)
        {
            return _gameResultRepository.GetAllByTableId(id);
        }

        public IEnumerable<GameResult> GetAllByGamerNickname(string nickname)
        {
            return _gameResultRepository.GetAllByGamerNickname(nickname);
        }

        public void AddGameResult(GameResult gameResult)
        {
            _gameResultRepository.Add(gameResult);
        }

        public void AddGameResults(List<GameResult> gameResults)
        {
            _gameResultRepository.AddMany(gameResults);
        }

        public void EditGameResult(GameResult gameResult)
        {
            _gameResultRepository.Edit(gameResult);
        }

        public void DeactivateGameResult(int id)
        {
            _gameResultRepository.Deactivate(id);
        }
    }
}