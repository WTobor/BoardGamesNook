using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNookNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GameParticipationRepository : IGameParticipationRepository
    {
        private List<GameParticipation> _gameParticipations = GameParticipationGenerator.gameParticipations;

        public GameParticipation Get(int id)
        {
            return _gameParticipations.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<GameParticipation> GetAll()
        {
            return _gameParticipations;
        }

        public void Add(GameParticipation gameParticipation)
        {
            _gameParticipations.Add(gameParticipation);
        }

        public void Edit(GameParticipation gameParticipation)
        {
            var oldGamer = _gameParticipations.Where(x => x.Id == gameParticipation.Id).FirstOrDefault();
            if (oldGamer != null)
            {
                _gameParticipations.Remove(oldGamer);
                _gameParticipations.Add(gameParticipation);
            }
        }

        public void Delete(int id)
        {
            var gameParticipation = _gameParticipations.Where(x => x.Id == id).FirstOrDefault();
            if (gameParticipation != null)
            {
                _gameParticipations.Remove(gameParticipation);
            }
        }
    }
}
