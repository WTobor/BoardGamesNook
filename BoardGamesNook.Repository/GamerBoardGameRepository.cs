using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GamerBoardGameRepository : IGamerBoardGameRepository
    {
        private readonly List<GamerBoardGame> _gamerBoardGames = GamerBoardGameGenerator.gamerBoardGames;

        public GamerBoardGame Get(int id)
        {
            return _gamerBoardGames.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GamerBoardGame> GetAll()
        {
            return _gamerBoardGames;
        }

        public IEnumerable<GamerBoardGame> GetAllByGamerNick(string gamerNick)
        {
            return _gamerBoardGames.Where(x => x.Gamer.Nick == gamerNick);
        }

        public void Add(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGames.Add(gamerBoardGame);
        }

        public void Edit(GamerBoardGame gamerBoardGame)
        {
            var oldGamer = _gamerBoardGames.FirstOrDefault(x => x.Id == gamerBoardGame.Id);
            if (oldGamer != null)
            {
                _gamerBoardGames.Remove(oldGamer);
                _gamerBoardGames.Add(gamerBoardGame);
            }
        }

        public void Delete(int id)
        {
            var gamerBoardGame = _gamerBoardGames.FirstOrDefault(x => x.Id == id);
            if (gamerBoardGame != null)
                _gamerBoardGames.Remove(gamerBoardGame);
        }
    }
}