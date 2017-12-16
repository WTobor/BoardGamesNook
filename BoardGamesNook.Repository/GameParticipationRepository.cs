using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GameParticipationRepository : IGameParticipationRepository
    {
        private readonly List<GameParticipation> _gameParticipations = GameParticipationGenerator.gameParticipations;

        public GameParticipation Get(int id)
        {
            return _gameParticipations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameParticipation> GetAll()
        {
            return _gameParticipations;
        }

        public IEnumerable<GameParticipation> GetAllByTableId(int tableId)
        {
            return _gameParticipations.Where(x => x.GameTableId == tableId).ToList();
        }

        public void Add(GameParticipation gameParticipation)
        {
            _gameParticipations.Add(gameParticipation);
        }

        public void Edit(GameParticipation gameParticipation)
        {
            var oldGamer = _gameParticipations.FirstOrDefault(x => x.Id == gameParticipation.Id);
            if (oldGamer != null)
            {
                _gameParticipations.Remove(oldGamer);
                _gameParticipations.Add(gameParticipation);
            }
        }

        public void Delete(int id)
        {
            var gameParticipation = _gameParticipations.FirstOrDefault(x => x.Id == id);
            if (gameParticipation != null)
                _gameParticipations.Remove(gameParticipation);
        }
    }
}