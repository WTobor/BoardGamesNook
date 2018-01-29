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
        private readonly List<GamerBoardGame> _gamerBoardGames = GamerBoardGameGenerator.gamerBoardGames;

        public GamerBoardGame GetGamerBoardGame(int id)
        {
            return _gamerBoardGames.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGames()
        {
            return _gamerBoardGames;
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNickname(string gamerNickname)
        {
            return _gamerBoardGames.Where(x => x.Gamer.Nickname == gamerNickname);
        }

        public void AddGamerBoardGame(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGames.Add(gamerBoardGame);
        }

        public void EditGamerBoardGame(GamerBoardGame gamerBoardGame)
        {
            gamerBoardGame.ModifiedDate = DateTimeOffset.Now;
            gamerBoardGame.Active = false;
        }

        public void DeleteGamerBoardGame(int id)
        {
            var gamerBoardGame = _gamerBoardGames.FirstOrDefault(x => x.Id == id);
            if (gamerBoardGame != null)
                _gamerBoardGames.Remove(gamerBoardGame);
        }
    }
}