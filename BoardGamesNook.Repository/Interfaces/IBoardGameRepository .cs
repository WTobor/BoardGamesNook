using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IBoardGameRepository
    {
        BoardGame Get(int id);

        IEnumerable<BoardGame> GetAll();

        void Add(BoardGame boardGame);

        void Edit(BoardGame boardGame);

        void Delete(int id);
    }
}