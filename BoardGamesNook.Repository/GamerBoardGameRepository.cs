using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GamerBoardGameRepository : IGamerBoardGameRepository
    {
        private readonly List<GamerBoardGame> _gamerBoardGames = GamerBoardGameGenerator.GamerBoardGames;

        public GamerBoardGame Get(int id)
        {
            return _gamerBoardGames.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GamerBoardGame> GetAll()
        {
            return _gamerBoardGames;
        }

        public IEnumerable<GamerBoardGame> GetAllByGamerNickname(string gamerNickname)
        {
            return _gamerBoardGames.Where(x => x.Gamer.Nickname == gamerNickname);
        }

        public void Add(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGames.Add(gamerBoardGame);
        }

        public void Edit(GamerBoardGame gamerBoardGame)
        {
            gamerBoardGame.ModifiedDate = DateTimeOffset.Now;
            gamerBoardGame.Active = false;
        }

        public void Deactivate(int id)
        {
            var gamerBoardGame = _gamerBoardGames.FirstOrDefault(x => x.Id == id);
            if (gamerBoardGame != null)
            {
                gamerBoardGame.Active = false;
                gamerBoardGame.ModifiedDate = DateTimeOffset.Now;
            }
        }
    }
}