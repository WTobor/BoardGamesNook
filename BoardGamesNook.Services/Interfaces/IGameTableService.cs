using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameTableService
    {
        GameTable GetGameTable(int id);

        IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname);

        IEnumerable<GameTable> GetAllGameTables();

        IEnumerable<BoardGame> GetAvailableTableBoardGameListById(int id);

        void CreateGameTable(GameTable gameTable, IEnumerable<int> tableBoardGameIdList);

        void EditGameTable(int id, List<int> tableBoardGameIdList);

        void EditParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer);

        void DeleteGameTable(int id);
    }
}