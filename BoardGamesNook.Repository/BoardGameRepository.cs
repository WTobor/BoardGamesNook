using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoardGamesNook.Repository
{
    public class BoardGameRepository : IBoardGameRepository
    {
        public static List<BoardGame> _boardGames = new List<BoardGame>()
        {
            new BoardGame()
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
            },
            new BoardGame()
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
            }
        };

        public BoardGame Get(int id)
        {
            return _boardGames.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _boardGames;
        }

        public void Add(BoardGame boardGame)
        {
            _boardGames.Add(boardGame);
        }

        public void Edit(BoardGame boardGame)
        {
            var oldGamer = _boardGames.Where(x => x.Id == boardGame.Id).FirstOrDefault();
            if (oldGamer != null)
            {
                _boardGames.Remove(oldGamer);
                _boardGames.Add(boardGame);
            }
        }

        public void Delete(int id)
        {
            var boardGame = _boardGames.Where(x => x.Id == id).FirstOrDefault();
            if (boardGame != null)
            {
                _boardGames.Remove(boardGame);
            }
        }
    }
}