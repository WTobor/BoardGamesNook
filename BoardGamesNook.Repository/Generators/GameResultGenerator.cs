using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class GameResultGenerator
    {
        public static GameResult gameResult1 = new GameResult
        {
            Id = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer1.Id,
            GameTableId = GameTableGenerator.gameTable1.Id,
            GameTable = GameTableGenerator.gameTable1,
            GamerId = GamerGenerator.gamer1.Id,
            Gamer = GamerGenerator.gamer1,
            BoardGame = BoardGameGenerator.boardGame1,
            BoardGameId = BoardGameGenerator.boardGame1.Id,
            Points = 20,
            Place = 1,
            PlayersNumber = 2
        };

        public static GameResult gameResult2 = new GameResult
        {
            Id = 2,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer2.Id,
            GameTableId = GameTableGenerator.gameTable1.Id,
            GameTable = GameTableGenerator.gameTable1,
            GamerId = GamerGenerator.gamer2.Id,
            Gamer = GamerGenerator.gamer2,
            BoardGame = BoardGameGenerator.boardGame1,
            BoardGameId = BoardGameGenerator.boardGame1.Id,
            Points = 15,
            Place = 2,
            PlayersNumber = 2
        };

        public static GameResult gameResult3 = new GameResult
        {
            Id = 3,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer1.Id,
            GameTableId = GameTableGenerator.gameTable2.Id,
            GameTable = GameTableGenerator.gameTable2,
            GamerId = GamerGenerator.gamer1.Id,
            Gamer = GamerGenerator.gamer1,
            BoardGame = BoardGameGenerator.boardGame2,
            BoardGameId = BoardGameGenerator.boardGame2.Id,
            Points = 138,
            Place = 1,
            PlayersNumber = 1
        };

        public static List<GameResult> gameResults = new List<GameResult>
        {
            gameResult1,
            gameResult2,
            gameResult3
        };
    }
}