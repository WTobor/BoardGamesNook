using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public static class BoardGameGenerator
    {
        public static readonly BoardGame boardGame1 = new BoardGame()
        {
            Id = 1,
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

        public static BoardGame boardGame2 = new BoardGame()
        {
            Id = 2,
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

        public static BoardGame boardGame3 = new BoardGame()
        {
            Id = 3,
            Name = "Terra Mystica",
            Description = "Opis gry Terra Mystica",
            MinPlayers = 2,
            MaxPlayers = 5,
            MinAge = 12,
            MinTime = 60,
            MaxTime = 150,
            BGGId = 120677,
            IsExpansion = false,
            ParentBoardGame = null,
            Active = true,
            IsConfirmed = true,
            ImageUrl = "http://cf.geekdo-images.com/images/pic1356616_t.jpg"
        };

        public static List<BoardGame> boardGames = new List<BoardGame>()
        {
            boardGame1,
            boardGame2,
            boardGame3
        };
    }
}
