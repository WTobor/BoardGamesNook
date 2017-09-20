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

        public static GamerBoardGame gamerBoardGame4 = new GamerBoardGame()
        {
            Id = 4,
            Active = true,
            GamerId = GamerGenerator.gamer3.Id,
            Gamer = GamerGenerator.gamer3,
            BoardGameId = BoardGameGenerator.boardGame3.Id,
            BoardGame = BoardGameGenerator.boardGame3
        };

        public static GamerBoardGame gamerBoardGame5 = new GamerBoardGame()
        {
            Id = 5,
            Active = true,
            GamerId = GamerGenerator.gamer3.Id,
            Gamer = GamerGenerator.gamer3,
            BoardGameId = BoardGameGenerator.boardGame4.Id,
            BoardGame = BoardGameGenerator.boardGame4
        };

        public static GamerBoardGame gamerBoardGame6 = new GamerBoardGame()
        {
            Id = 6,
            Active = true,
            GamerId = GamerGenerator.gamer4.Id,
            Gamer = GamerGenerator.gamer4,
            BoardGameId = BoardGameGenerator.boardGame3.Id,
            BoardGame = BoardGameGenerator.boardGame3
        };

        public static GamerBoardGame gamerBoardGame7 = new GamerBoardGame()
        {
            Id = 7,
            Active = true,
            GamerId = GamerGenerator.gamer3.Id,
            Gamer = GamerGenerator.gamer3,
            BoardGameId = BoardGameGenerator.boardGame5.Id,
            BoardGame = BoardGameGenerator.boardGame5
        };

        public static List<GamerBoardGame> gamerBoardGames = new List<GamerBoardGame>()
        {
            gamerBoardGame1,
            gamerBoardGame2,
            gamerBoardGame3,
            gamerBoardGame4,
            gamerBoardGame5
        };
    }
}