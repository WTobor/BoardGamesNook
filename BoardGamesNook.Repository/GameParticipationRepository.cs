using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GameParticipationRepository : IGameParticipationRepository
    {
        private readonly List<GameParticipation> _gameParticipations = GameParticipationGenerator.GameParticipations;

        public GameParticipation GetGameParticipation(int id)
        {
            return _gameParticipations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameParticipation> GetAllGameParticipations()
        {
            return _gameParticipations;
        }

        public IEnumerable<GameParticipation> GetAllGameParticipationsByTableId(int tableId)
        {
            return _gameParticipations.Where(x => x.GameTableId == tableId).ToList();
        }

        public void AddGameParticipation(GameParticipation gameParticipation)
        {
            _gameParticipations.Add(gameParticipation);
        }

        public void EditGameParticipation(GameParticipation gameParticipation)
        {
            gameParticipation.Active = false;
            gameParticipation.ModifiedDate = DateTimeOffset.Now;
        }

        public void DeleteGameParticipation(int id)
        {
            var gameParticipation = _gameParticipations.FirstOrDefault(x => x.Id == id);
            if (gameParticipation != null)
                _gameParticipations.Remove(gameParticipation);
        }
    }
}