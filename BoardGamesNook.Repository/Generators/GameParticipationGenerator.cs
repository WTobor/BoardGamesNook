using System;
using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators.Constants;

namespace BoardGamesNook.Repository.Generators
{
    public static class GameParticipationGenerator
    {
        public static GameParticipation gameParticipation1 = new GameParticipation
        {
            Id = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer1.Id,
            GameTableId = GameTableGenerator.gameTable1.Id,
            GameTable = GameTableGenerator.gameTable1,
            GamerId = GamerGenerator.gamer1.Id,
            Gamer = GamerGenerator.gamer1,
            Status = (int) Enums.GameParticipationStatuses.Yes,
            IsConfirmed = false,
            Active = true
        };

        public static GameParticipation gameParticipation2 = new GameParticipation
        {
            Id = 2,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer2.Id,
            GameTableId = GameTableGenerator.gameTable1.Id,
            GameTable = GameTableGenerator.gameTable1,
            GamerId = GamerGenerator.gamer2.Id,
            Gamer = GamerGenerator.gamer2,
            Status = (int) Enums.GameParticipationStatuses.No,
            IsConfirmed = false,
            Active = true
        };

        public static GameParticipation gameParticipation3 = new GameParticipation
        {
            Id = 3,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer1.Id,
            GameTableId = GameTableGenerator.gameTable2.Id,
            GameTable = GameTableGenerator.gameTable2,
            GamerId = GamerGenerator.gamer1.Id,
            Gamer = GamerGenerator.gamer1,
            Status = (int) Enums.GameParticipationStatuses.Maybe,
            IsConfirmed = false,
            Active = true
        };

        public static List<GameParticipation> gameParticipations = new List<GameParticipation>
        {
            gameParticipation1,
            gameParticipation2,
            gameParticipation3
        };
    }
}