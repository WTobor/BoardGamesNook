using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerBoardGameService
    {
        GamerBoardGame Get(int id);

        IEnumerable<GamerBoardGame> GetAll();

        IEnumerable<GamerBoardGame> GetAllByGamerId(int gamerId);

        void Add(GamerBoardGame boardGame);

        void Edit(GamerBoardGame boardGame);

        void Delete(int id);
    }
}