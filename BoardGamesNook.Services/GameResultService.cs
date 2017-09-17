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

        public GameResult Get(int id)
        {
            return _gameResultRepository.Get(id);
        }

        public IEnumerable<GameResult> GetAll()
        {
            return _gameResultRepository.GetAll();
        }

        public IEnumerable<GameResult> GetAllByTableId(int id)
        {
            return _gameResultRepository.GetAllByTableId(id);
        }

        public IEnumerable<GameResult> GetAllByGamerNick(string nick)
        {
            return _gameResultRepository.GetAllByGamerNick(nick);
        }

        public void Add(GameResult gameResult)
        {
            _gameResultRepository.Add(gameResult);
        }

        public void Edit(GameResult gameResult)
        {
            _gameResultRepository.Edit(gameResult);
        }

        public void Delete(int id)
        {
            _gameResultRepository.Delete(id);
        }
    }
}