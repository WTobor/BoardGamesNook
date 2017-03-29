using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;

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
                MinTime = new TimeSpan(0, 0, 60),
                MaxTime = new TimeSpan(0, 0, 120),
                BGGId = null,
                IsExpansion = false,
                ParentBoardGame = null,
                Active = true,
                IsConfirmed = true
            },
            new BoardGame()
            {
                Id = 2,
                Name = "Dixit",
                Description = "Opis gry Dixit",
                MinPlayers = 3,
                MaxPlayers = 6,
                MinAge = 6,
                MinTime = new TimeSpan(0, 0, 30),
                MaxTime = new TimeSpan(0, 0, 30),
                BGGId = null,
                IsExpansion = false,
                ParentBoardGame = null,
                Active = true,
                IsConfirmed = true
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