using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class GamerBoardGameGenerator
    {
        public static GamerBoardGame GamerBoardGame1 = new GamerBoardGame
        {
            Id = 1,
            Active = true,
            GamerId = GamerGenerator.Gamer1.Id,
            Gamer = GamerGenerator.Gamer1,
            BoardGameId = BoardGameGenerator.BoardGame1.Id,
            BoardGame = BoardGameGenerator.BoardGame1
        };

        public static GamerBoardGame GamerBoardGame2 = new GamerBoardGame
        {
            Id = 2,
            Active = true,
            GamerId = GamerGenerator.Gamer1.Id,
            Gamer = GamerGenerator.Gamer1,
            BoardGameId = BoardGameGenerator.BoardGame2.Id,
            BoardGame = BoardGameGenerator.BoardGame2
        };

        public static GamerBoardGame GamerBoardGame3 = new GamerBoardGame
        {
            Id = 3,
            Active = true,
            GamerId = GamerGenerator.Gamer2.Id,
            Gamer = GamerGenerator.Gamer2,
            BoardGameId = BoardGameGenerator.BoardGame2.Id,
            BoardGame = BoardGameGenerator.BoardGame2
        };

        public static GamerBoardGame GamerBoardGame4 = new GamerBoardGame
        {
            Id = 4,
            Active = true,
            GamerId = GamerGenerator.Gamer3.Id,
            Gamer = GamerGenerator.Gamer3,
            BoardGameId = BoardGameGenerator.BoardGame3.Id,
            BoardGame = BoardGameGenerator.BoardGame3
        };

        public static GamerBoardGame GamerBoardGame5 = new GamerBoardGame
        {
            Id = 5,
            Active = true,
            GamerId = GamerGenerator.Gamer3.Id,
            Gamer = GamerGenerator.Gamer3,
            BoardGameId = BoardGameGenerator.BoardGame4.Id,
            BoardGame = BoardGameGenerator.BoardGame4
        };

        public static GamerBoardGame GamerBoardGame6 = new GamerBoardGame
        {
            Id = 6,
            Active = true,
            GamerId = GamerGenerator.Gamer4.Id,
            Gamer = GamerGenerator.Gamer4,
            BoardGameId = BoardGameGenerator.BoardGame3.Id,
            BoardGame = BoardGameGenerator.BoardGame3
        };

        public static GamerBoardGame GamerBoardGame7 = new GamerBoardGame
        {
            Id = 7,
            Active = true,
            GamerId = GamerGenerator.Gamer3.Id,
            Gamer = GamerGenerator.Gamer3,
            BoardGameId = BoardGameGenerator.BoardGame5.Id,
            BoardGame = BoardGameGenerator.BoardGame5
        };

        public static List<GamerBoardGame> GamerBoardGames = new List<GamerBoardGame>
        {
            GamerBoardGame1,
            GamerBoardGame2,
            GamerBoardGame3,
            GamerBoardGame4,
            GamerBoardGame5
        };
    }
}