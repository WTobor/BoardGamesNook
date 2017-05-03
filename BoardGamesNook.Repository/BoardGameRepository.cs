using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Repository.Generators;

namespace BoardGamesNook.Repository
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private List<BoardGame> _boardGames = BoardGameGenerator.boardGames;

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