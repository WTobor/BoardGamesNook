using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameTableService
    {
        GameTable GetGameTable(int id);

        IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname);

        IEnumerable<GameTable> GetAllGameTables();

        IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table);

        void CreateGameTable(GameTable gameTable, List<int> tableBoardGameIdList);

        void EditGameTable(GameTable gameTable);

        void EditParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer);

        void DeleteGameTable(int id);
    }
}