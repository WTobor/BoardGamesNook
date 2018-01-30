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
            return _gameParticipationRepository.GetGameParticipation(id);
        }

        public IEnumerable<GameParticipation> GetAllGameParticipations()
        {
            return _gameParticipationRepository.GetAllGameParticipations();
        }

        public IEnumerable<GameParticipation> GetAllGameParticipationsByTableId(int id)
        {
            return _gameParticipationRepository.GetAllGameParticipationsByTableId(id);
        }

        public void AddGameParticipation(GameParticipation gameParticipation)
        {
            _gameParticipationRepository.AddGameParticipation(gameParticipation);
        }

        public void Edit(GameParticipation gameParticipation)
        {
            _gameParticipationRepository.EditGameParticipation(gameParticipation);
        }

        public void Delete(int id)
        {
            _gameParticipationRepository.DeleteGameParticipation(id);
        }
    }
}