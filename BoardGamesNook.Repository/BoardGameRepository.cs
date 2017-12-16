using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly List<BoardGame> _boardGames = BoardGameGenerator.boardGames;

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
            var oldGamer = _boardGames.FirstOrDefault(x => x.Id == boardGame.Id);
            if (oldGamer != null)
            {
                _boardGames.Remove(oldGamer);
                _boardGames.Add(boardGame);
            }
        }

        public void Delete(int id)
        {
            var boardGame = _boardGames.FirstOrDefault(x => x.Id == id);
            if (boardGame != null)
                _boardGames.Remove(boardGame);
        }
    }
}