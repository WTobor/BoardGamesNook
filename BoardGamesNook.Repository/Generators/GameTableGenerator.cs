using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class GameTableGenerator
    {
        public static GameTable gameTable1 = new GameTable
        {
            Id = 300,
            Name = "Stół do Osadników z Catanu + żeglarze",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer1.Id,
            CreatedGamer = GamerGenerator.gamer1,
            IsFull = false,
            IsPrivate = false,
            City = "Wrocław",
            Street = "Legnicka",
            BoardGames = new List<BoardGame>
            {
                BoardGameGenerator.boardGame1
            },
            MinPlayersNumber = 2,
            MaxPlayersNumber = 4,
            GameParticipations = null,
            Active = true
        };

        public static GameTable gameTable2 = new GameTable
        {
            Id = 301,
            Name = "Wieczorne spotkanie na Dixit i Terra Mysticę",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer2.Id,
            CreatedGamer = GamerGenerator.gamer2,
            IsFull = false,
            IsPrivate = false,
            City = "Warszawa",
            Street = "Wyszyńskiego",
            BoardGames = new List<BoardGame>
            {
                BoardGameGenerator.boardGame2,
                BoardGameGenerator.boardGame3
            },
            MinPlayersNumber = 2,
            MaxPlayersNumber = 4,
            GameParticipations = null,
            Active = true
        };

        public static GameTable gameTable3 = new GameTable
        {
            Id = 302,
            Name = "Prywatny stół dla wtajemniczonych",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer1.Id,
            CreatedGamer = GamerGenerator.gamer1,
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

        public static GameTable gameTable4 = new GameTable
        {
            Id = 304,
            Name = "Planszówki u Maćka",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer4.Id,
            CreatedGamer = GamerGenerator.gamer4,
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

        public static GameTable gameTable5 = new GameTable
        {
            Id = 305,
            Name = "Rozgrywki w Dixit",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedGamerId = GamerGenerator.gamer3.Id,
            CreatedGamer = GamerGenerator.gamer3,
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

        public static List<GameTable> gameTables = new List<GameTable>
        {
            gameTable1,
            gameTable2,
            gameTable3,
            gameTable4,
            gameTable5
        };
    }
}