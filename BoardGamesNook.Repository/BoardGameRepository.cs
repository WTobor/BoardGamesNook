using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly List<BoardGame> _boardGames = BoardGameGenerator.BoardGames;

        public BoardGame Get(int id)
        {
            return _boardGames.FirstOrDefault(x => x.Id == id);
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
            var dbBoardGame = _boardGames.FirstOrDefault(x => x.Id == boardGame.Id);
            if (dbBoardGame != null)
            {
                dbBoardGame.Name = boardGame.Name;
                dbBoardGame.Description = boardGame.Description;
                dbBoardGame.MinPlayers = boardGame.MinPlayers;
                dbBoardGame.MaxPlayers = boardGame.MaxPlayers;
                dbBoardGame.MinTime = boardGame.MinTime;
                dbBoardGame.MaxTime = boardGame.MaxTime;
                dbBoardGame.ModifiedDate = DateTimeOffset.Now;
            }
        }

        public void Deactivate(int id)
        {
            var boardGame = _boardGames.FirstOrDefault(x => x.Id == id);
            if (boardGame != null)
            {
                boardGame.Active = false;
                boardGame.ModifiedDate = DateTimeOffset.Now;
            }
        }
    }
}