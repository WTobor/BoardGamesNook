using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerBoardGameService
    {
        GamerBoardGame GetGamerBoardGame(int id);

        IEnumerable<GamerBoardGame> GetAllGamerBoardGames();
        IEnumerable<BoardGame> GetGamerAvailableBoardGameList(string nickname);

        IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNickname(string gamerNickname);

        void Add(int boardGameId, Gamer gamer);

        void EditGamerBoardGame(int gamerBoardGameId);

        void DeactivateGamerBoardGame(int id);
    }
}