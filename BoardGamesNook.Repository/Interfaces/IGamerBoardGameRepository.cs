using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGamerBoardGameRepository
    {
        GamerBoardGame Get(int id);

        IEnumerable<GamerBoardGame> GetAll();

        IEnumerable<GamerBoardGame> GetAllByGamerId(int gamerId);

        void Add(GamerBoardGame gamerBoardGame);

        void Edit(GamerBoardGame gamerBoardGame);

        void Delete(int id);
    }
}
