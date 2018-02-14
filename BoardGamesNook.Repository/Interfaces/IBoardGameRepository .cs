using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IBoardGameRepository
    {
        BoardGame Get(int id);

        IEnumerable<BoardGame> GetAll();

        void Add(BoardGame boardGame);

        bool CheckIfExists(string name);

        void Edit(BoardGame boardGame);

        void Deactivate(int id);
    }
}