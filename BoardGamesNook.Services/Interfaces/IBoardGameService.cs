using System.Collections.Generic;
using BoardGameGeekIntegration.Models;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IBoardGameService
    {
        BoardGame Get(int id);

        IEnumerable<BoardGame> GetAllGamerBoardGames();

        void Add(BoardGame boardGame);

        List<SimilarBoardGame> AddOrGetSimilar(string name);

        void Edit(BoardGame boardGame);

        void DeactivateBoardGame(int id);
        IEnumerable<BoardGame> GetAllByIds(IEnumerable<int> tableBoardGameIdList);
    }
}