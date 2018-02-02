using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGamerBoardGameRepository
    {
        GamerBoardGame Get(int id);

        IEnumerable<GamerBoardGame> GetAll();

        IEnumerable<GamerBoardGame> GetAllByGamerNickname(string gamerNickname);

        void Add(GamerBoardGame gamerBoardGame);

        void Edit(GamerBoardGame gamerBoardGame);

        void Deactivate(int id);
    }
}