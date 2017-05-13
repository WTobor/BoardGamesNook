using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public class GameParticipationGenerator
    {
        public static readonly GameParticipation gameParticipation1 = new GameParticipation()
        {
            Id = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedUserId = GamerGenerator.gamer1.Id,
            GameTableId = GameTableGenerator.gameTable1.Id,
            GameTable = GameTableGenerator.gameTable1,
            GamerId = GamerGenerator.gamer1.Id,
            Gamer = GamerGenerator.gamer1,
            IsConfirmed = false,
            Active = true
        };

        public static GameParticipation gameParticipation2 = new GameParticipation()
        {
            Id = 2,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedUserId = GamerGenerator.gamer2.Id,
            GameTableId = GameTableGenerator.gameTable2.Id,
            GameTable = GameTableGenerator.gameTable2,
            GamerId = GamerGenerator.gamer2.Id,
            Gamer = GamerGenerator.gamer2,
            IsConfirmed = false,
            Active = true
        };

        public static GameParticipation gameParticipation3 = new GameParticipation()
        {
            Id = 3,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedUserId = GamerGenerator.gamer1.Id,
            GameTableId = GameTableGenerator.gameTable3.Id,
            GameTable = GameTableGenerator.gameTable3,
            GamerId = GamerGenerator.gamer1.Id,
            Gamer = GamerGenerator.gamer1,
            IsConfirmed = false,
            Active = true
        };

        public static List<GameParticipation> gameParticipations = new List<GameParticipation>()
        {
            gameParticipation1,
            gameParticipation2,
            gameParticipation3
        };
    }
}
