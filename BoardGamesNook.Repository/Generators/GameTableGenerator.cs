﻿using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class GameTableGenerator
    {
        public static GameTable gameTable1 = new GameTable()
        {
            Id = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer1.Id,
            CreatedGamer = GamerGenerator.gamer1,
            IsFull = false,
            IsPrivate = false,
            City = "Wrocław",
            Street = "Legnicka",
            BoardGames = new List<BoardGame>()
            {
                BoardGameGenerator.boardGame1
            },
            GameParticipationInfo = null,
            Active = true
        };

        public static GameTable gameTable2 = new GameTable()
        {
            Id = 2,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer2.Id,
            CreatedGamer = GamerGenerator.gamer2,
            IsFull = false,
            IsPrivate = false,
            City = "Warszawa",
            Street = "Wyszyńskiego",
            BoardGames = new List<BoardGame>()
            {
                BoardGameGenerator.boardGame2,
                BoardGameGenerator.boardGame3
            },
            GameParticipationInfo = null,
            Active = true
        };

        public static GameTable gameTable3 = new GameTable()
        {
            Id = 3,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer1.Id,
            CreatedGamer = GamerGenerator.gamer1,
            IsFull = false,
            IsPrivate = false,
            City = "Poznań",
            Street = "Rynek",
            BoardGames = null,
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
