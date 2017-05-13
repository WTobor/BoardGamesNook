using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class GameParticipationService : IGameParticipationService
    {
        private readonly IGameParticipationRepository _gameParticipationRepository;

        public GameParticipationService(IGameParticipationRepository gameParticipationRepository)
        {
            _gameParticipationRepository = gameParticipationRepository;
        }

        public GameParticipation Get(int id)
        {
            return _gameParticipationRepository.Get(id);
        }

        public IEnumerable<GameParticipation> GetAll()
        {
            return _gameParticipationRepository.GetAll();
        }

        public IEnumerable<GameParticipation> GetAllByTableId(int id)
        {
            return _gameParticipationRepository.GetAllByTableId(id);
        }

        public void Add(GameParticipation gameParticipation)
        {
            _gameParticipationRepository.Add(gameParticipation);
        }

        public void Edit(GameParticipation gameParticipation)
        {
            _gameParticipationRepository.Edit(gameParticipation);
        }

        public void Delete(int id)
        {
            _gameParticipationRepository.Delete(id);
        }
    }
}
