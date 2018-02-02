using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class GameResultGenerator
    {
        public static GameResult GameResult1 = new GameResult
        {
            Id = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer1.Id,
            GameTableId = GameTableGenerator.GameTable1.Id,
            GameTable = GameTableGenerator.GameTable1,
            GamerId = GamerGenerator.Gamer1.Id,
            Gamer = GamerGenerator.Gamer1,
            BoardGame = BoardGameGenerator.BoardGame1,
            BoardGameId = BoardGameGenerator.BoardGame1.Id,
            Points = 20,
            Place = 1,
            PlayersNumber = 2
        };

        public static GameResult GameResult2 = new GameResult
        {
            Id = 2,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer2.Id,
            GameTableId = GameTableGenerator.GameTable1.Id,
            GameTable = GameTableGenerator.GameTable1,
            GamerId = GamerGenerator.Gamer2.Id,
            Gamer = GamerGenerator.Gamer2,
            BoardGame = BoardGameGenerator.BoardGame1,
            BoardGameId = BoardGameGenerator.BoardGame1.Id,
            Points = 15,
            Place = 2,
            PlayersNumber = 2
        };

        public static GameResult GameResult3 = new GameResult
        {
            Id = 3,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer1.Id,
            GameTableId = GameTableGenerator.GameTable2.Id,
            GameTable = GameTableGenerator.GameTable2,
            GamerId = GamerGenerator.Gamer1.Id,
            Gamer = GamerGenerator.Gamer1,
            BoardGame = BoardGameGenerator.BoardGame2,
            BoardGameId = BoardGameGenerator.BoardGame2.Id,
            Points = 138,
            Place = 1,
            PlayersNumber = 1
        };

        public static List<GameResult> GameResults = new List<GameResult>
        {
            GameResult1,
            GameResult2,
            GameResult3
        };
    }
}