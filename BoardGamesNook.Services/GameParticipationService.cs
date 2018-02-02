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

        public GameParticipation GetGameParticipation(int id)
        {
            return _gameParticipationRepository.Get(id);
        }

        public IEnumerable<GameParticipation> GetAllGameParticipations()
        {
            return _gameParticipationRepository.GetAll();
        }

        public IEnumerable<GameParticipation> GetAllGameParticipationsByTableId(int id)
        {
            return _gameParticipationRepository.GetAllByTableId(id);
        }

        public void AddGameParticipation(GameParticipation gameParticipation)
        {
            _gameParticipationRepository.Add(gameParticipation);
        }

        public void Edit(GameParticipation gameParticipation)
        {
            _gameParticipationRepository.Edit(gameParticipation);
        }

        public void DeactivateGameParticipation(int id)
        {
            _gameParticipationRepository.Deactivate(id);
        }
    }
}