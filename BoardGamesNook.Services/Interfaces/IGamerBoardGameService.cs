using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerBoardGameService
    {
        GamerBoardGame GetGamerBoardGame(int id);

        IEnumerable<GamerBoardGame> GetAllGamerBoardGames();

        IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNickname(string gamerNickname);

        void Add(GamerBoardGame boardGame);

        void EditGamerBoardGame(GamerBoardGame boardGame);

        void DeleteGamerBoardGame(int id);
    }
}