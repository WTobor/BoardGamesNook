using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class GameTableGenerator
    {
        public static GameTable GameTable1 = new GameTable
        {
            Id = 300,
            Name = "Stół do Osadników z Catanu + żeglarze",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer1.Id,
            IsFull = false,
            IsPrivate = false,
            City = "Wrocław",
            Street = "Legnicka",
            BoardGames = new List<BoardGame>
            {
                BoardGameGenerator.BoardGame1
            },
            MinPlayersNumber = 2,
            MaxPlayersNumber = 4,
            GameParticipations = null,
            Active = true
        };

        public static GameTable GameTable2 = new GameTable
        {
            Id = 301,
            Name = "Wieczorne spotkanie na Dixit i Terra Mysticę",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer2.Id,
            IsFull = false,
            IsPrivate = false,
            City = "Warszawa",
            Street = "Wyszyńskiego",
            BoardGames = new List<BoardGame>
            {
                BoardGameGenerator.BoardGame2,
                BoardGameGenerator.BoardGame3
            },
            MinPlayersNumber = 2,
            MaxPlayersNumber = 4,
            GameParticipations = null,
            Active = true
        };

        public static GameTable GameTable3 = new GameTable
        {
            Id = 302,
            Name = "Prywatny stół dla wtajemniczonych",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer1.Id,
            IsFull = false,
            IsPrivate = true,
            City = "Poznań",
            Street = "Rynek",
            BoardGames = null,
            MinPlayersNumber = 2,
            MaxPlayersNumber = 2,
            GameParticipations = null,
            Active = true
        };

        public static GameTable GameTable4 = new GameTable
        {
            Id = 304,
            Name = "Planszówki u Maćka",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer4.Id,
            IsFull = false,
            IsPrivate = false,
            City = "Wrocław",
            Street = "Gliniana",
            BoardGames = null,
            MinPlayersNumber = 2,
            MaxPlayersNumber = 6,
            GameParticipations = null,
            Active = true
        };

        public static GameTable GameTable5 = new GameTable
        {
            Id = 305,
            Name = "Rozgrywki w Dixit",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.Gamer3.Id,
            IsFull = false,
            IsPrivate = false,
            City = "Gdańsk",
            Street = "Centralna",
            BoardGames = null,
            MinPlayersNumber = 4,
            MaxPlayersNumber = 6,
            GameParticipations = null,
            Active = true
        };

        public static List<GameTable> GameTables = new List<GameTable>
        {
            GameTable1,
            GameTable2,
            GameTable3,
            GameTable4,
            GameTable5
        };
    }
}