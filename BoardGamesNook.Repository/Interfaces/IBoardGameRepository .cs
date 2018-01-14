using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IBoardGameRepository
    {
        BoardGame GetGamerBoardGame(int id);

        IEnumerable<BoardGame> GetAllGamerBoardGames();

        void Add(BoardGame boardGame);

        void EditGamerBoardGame(BoardGame boardGame);

        void DeleteGamerBoardGame(int id);
    }
}