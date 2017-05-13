using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public class GameTableGenerator
    {
        public static readonly GameTable gameTable1 = new GameTable()
        {
            Id = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedUserId = GamerGenerator.gamer1.Id,
            IsFull = false,
            IsPrivate = false,
            City = "Wrocław",
            Street = "Legnicka",
            GameParticipationInfo = new List<GameParticipation>()
            {
                GameParticipationGenerator.gameParticipation1,
                GameParticipationGenerator.gameParticipation2
            },
            Active = true
        };

        public static GameTable gameTable2 = new GameTable()
        {
            Id = 2,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedUserId = GamerGenerator.gamer2.Id,
            IsFull = false,
            IsPrivate = false,
            City = "Warszawa",
            Street = "Wyszyńskiego",
            GameParticipationInfo = new List<GameParticipation>()
            {
                GameParticipationGenerator.gameParticipation3
            },
            Active = true
        };

        public static GameTable gameTable3 = new GameTable()
        {
            Id = 3,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedUserId = GamerGenerator.gamer1.Id,
            IsFull = false,
            IsPrivate = false,
            City = "Poznań",
            Street = "Rynek",
            GameParticipationInfo = null,
            Active = true
        };

        public static List<GameTable> gameTables = new List<GameTable>()
        {
            gameTable1,
            gameTable2,
            gameTable3
        };
    }
}
