using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class BoardGameGenerator
    {
        public static BoardGame BoardGame1 = new BoardGame
        {
            Id = 150,
            Name = "Osadnicy z Catanu",
            Description = "Opis gry Osadnicy z Catanu",
            MinPlayers = 3,
            MaxPlayers = 4,
            MinAge = 10,
            MinTime = 60,
            MaxTime = 120,
            BGGId = 13,
            IsExpansion = false,
            ParentBoardGame = null,
            Active = true,
            IsConfirmed = true,
            ImageUrl = "http://cf.geekdo-images.com/images/pic2419375_t.jpg"
        };

        public static BoardGame BoardGame2 = new BoardGame
        {
            Id = 151,
            Name = "Dixit",
            Description = "Opis gry Dixit",
            MinPlayers = 3,
            MaxPlayers = 6,
            MinAge = 6,
            MinTime = 30,
            MaxTime = 30,
            BGGId = 39856,
            IsExpansion = false,
            ParentBoardGame = null,
            Active = true,
            IsConfirmed = true,
            ImageUrl = "http://cf.geekdo-images.com/images/pic3483909_t.jpg"
        };

        public static BoardGame BoardGame3 = new BoardGame
        {
            Id = 152,
            Name = "Scythe",
            Description = "Opis gry Scythe",
            MinPlayers = 1,
            MaxPlayers = 5,
            MinAge = 12,
            MinTime = 90,
            MaxTime = 115,
            BGGId = 169786,
            IsExpansion = false,
            ParentBoardGame = null,
            Active = true,
            IsConfirmed = true,
            ImageUrl = "https://cf.geekdo-images.com/images/pic3163924_t.jpg"
        };

        public static BoardGame BoardGame4 = new BoardGame
        {
            Id = 153,
            Name = "Sabotażysta",
            Description = "Opis gry Sabotażysta",
            MinPlayers = 3,
            MaxPlayers = 10,
            MinAge = 8,
            MinTime = 30,
            MaxTime = 30,
            BGGId = 9220,
            IsExpansion = false,
            ParentBoardGame = null,
            Active = true,
            IsConfirmed = true,
            ImageUrl = "https://cf.geekdo-images.com/images/pic2602139_t.jpg"
        };

        public static BoardGame BoardGame5 = new BoardGame
        {
            Id = 154,
            Name = "Splendor",
            Description = "Opis gry Splendor",
            MinPlayers = 2,
            MaxPlayers = 4,
            MinAge = 10,
            MinTime = 30,
            MaxTime = 30,
            BGGId = 148228,
            IsExpansion = false,
            ParentBoardGame = null,
            Active = true,
            IsConfirmed = true,
            ImageUrl = "https://cf.geekdo-images.com/images/pic1904079_t.jpg"
        };

        public static List<BoardGame> BoardGames = new List<BoardGame>
        {
            BoardGame1,
            BoardGame2,
            BoardGame3,
            BoardGame4,
            BoardGame5,
            BoardGame1,
            BoardGame2,
            BoardGame3,
            BoardGame4,
            BoardGame5
        };
    }
}