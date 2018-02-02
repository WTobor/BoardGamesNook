using System;
using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators.Constants;

namespace BoardGamesNook.Repository.Generators
{
    public static class GameParticipationGenerator
    {
        public static GameParticipation GameParticipation1 = new GameParticipation
        {
            Id = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer1.Id,
            GameTableId = GameTableGenerator.GameTable1.Id,
            GameTable = GameTableGenerator.GameTable1,
            GamerId = GamerGenerator.Gamer1.Id,
            Gamer = GamerGenerator.Gamer1,
            Status = (int) Enums.GameParticipationStatuses.Yes,
            IsConfirmed = false,
            Active = true
        };

        public static GameParticipation GameParticipation2 = new GameParticipation
        {
            Id = 2,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer2.Id,
            GameTableId = GameTableGenerator.GameTable1.Id,
            GameTable = GameTableGenerator.GameTable1,
            GamerId = GamerGenerator.Gamer2.Id,
            Gamer = GamerGenerator.Gamer2,
            Status = (int) Enums.GameParticipationStatuses.No,
            IsConfirmed = false,
            Active = true
        };

        public static GameParticipation GameParticipation3 = new GameParticipation
        {
            Id = 3,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer1.Id,
            GameTableId = GameTableGenerator.GameTable2.Id,
            GameTable = GameTableGenerator.GameTable2,
            GamerId = GamerGenerator.Gamer1.Id,
            Gamer = GamerGenerator.Gamer1,
            Status = (int) Enums.GameParticipationStatuses.Maybe,
            IsConfirmed = false,
            Active = true
        };

        public static List<GameParticipation> GameParticipations = new List<GameParticipation>
        {
            GameParticipation1,
            GameParticipation2,
            GameParticipation3
        };
    }
}