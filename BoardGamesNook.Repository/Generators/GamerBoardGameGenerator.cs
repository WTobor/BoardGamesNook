using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class GamerBoardGameGenerator
    {
        public static GamerBoardGame gamerBoardGame1 = new GamerBoardGame()
        {
            Id = 1,
            Active = true,
            GamerId = GamerGenerator.gamer1.Id,
            Gamer = GamerGenerator.gamer1,
            BoardGameId = BoardGameGenerator.boardGame1.Id,
            BoardGame = BoardGameGenerator.boardGame1
        };

        public static GamerBoardGame gamerBoardGame2 = new GamerBoardGame()
        {
            Id = 2,
            Active = true,
            GamerId = GamerGenerator.gamer1.Id,
            Gamer = GamerGenerator.gamer1,
            BoardGameId = BoardGameGenerator.boardGame2.Id,
            BoardGame = BoardGameGenerator.boardGame2
        };

        public static GamerBoardGame gamerBoardGame3 = new GamerBoardGame()
        {
            Id = 3,
            Active = true,
            GamerId = GamerGenerator.gamer2.Id,
            Gamer = GamerGenerator.gamer2,
            BoardGameId = BoardGameGenerator.boardGame2.Id,
            BoardGame = BoardGameGenerator.boardGame2
        };

        public static List<GamerBoardGame> gamerBoardGames = new List<GamerBoardGame>()
        {
            gamerBoardGame1,
            gamerBoardGame2,
            gamerBoardGame3
        };
    }
}