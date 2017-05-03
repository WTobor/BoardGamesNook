
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
            GamerId = 1,
            Gamer = GamerGenerator.gamer1,
            BoardGameId = 1,
            BoardGame = BoardGameGenerator.boardGame1
        };

        public static GamerBoardGame gamerBoardGame2 = new GamerBoardGame()
        {
            Id = 2,
            Active = true,
            GamerId = 1,
            Gamer = GamerGenerator.gamer1,
            BoardGameId = 2,
            BoardGame = BoardGameGenerator.boardGame2
        };

        public static GamerBoardGame gamerBoardGame3 = new GamerBoardGame()
        {
            Id = 3,
            Active = true,
            GamerId = 2,
            Gamer = GamerGenerator.gamer1,
            BoardGameId = 2,
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
