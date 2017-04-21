using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IBoardGameService
    {
        BoardGame Get(int id);

        IEnumerable<BoardGame> GetAll();

        void Add(BoardGame boardGame);

        void Edit(BoardGame boardGame);

        void Delete(int id);
    }
}