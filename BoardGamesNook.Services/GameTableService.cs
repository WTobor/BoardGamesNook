using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services 
{
    public class GameTableService : IGameTableService
    {
        private readonly IGameTableRepository _gameTableRepository;

        public GameTableService(IGameTableRepository gameTableRepository)
        {
            _gameTableRepository = gameTableRepository;
        }

        public GameTable Get(int id)
        {
            return _gameTableRepository.Get(id);
        }

        public IEnumerable<GameTable> GetAll()
        {
            return _gameTableRepository.GetAll();
        }

        public void Add(GameTable gameTable)
        {
            _gameTableRepository.Add(gameTable);
        }

        public void Edit(GameTable gameTable)
        {
            _gameTableRepository.Edit(gameTable);
        }

        public void Delete(int id)
        {
            _gameTableRepository.Delete(id);
        }
    }
}
