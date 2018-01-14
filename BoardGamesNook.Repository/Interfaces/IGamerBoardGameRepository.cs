using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGamerBoardGameRepository
    {
        GamerBoardGame GetGamerBoardGame(int id);

        IEnumerable<GamerBoardGame> GetAllGamerBoardGames();

        IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNick(string gamerNick);

        void AddGamerBoardGame(GamerBoardGame gamerBoardGame);

        void EditGamerBoardGame(GamerBoardGame gamerBoardGame);

        void DeleteGamerBoardGame(int id);
    }
}