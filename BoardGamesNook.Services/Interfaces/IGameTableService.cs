using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Objects;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameTableService
    {
        GameTable GetGameTable(int id);

        GameTableObj GetGameTableObj(int id);

        IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname);

        IEnumerable<GameTable> GetAllGameTablesWithoutResultsByGamerNickname(string gamerNickname);

        IEnumerable<GameTableObj> GetAllGameTableObjsWithoutResultsByGamerNickname(string gamerNickname);

        IEnumerable<GameTableObj> GetAllGameTableObjsByGamerNickname(string gamerNickname);

        IEnumerable<GameTable> GetAllGameTables();

        IEnumerable<GameTableObj> GetAllGameTableObjs();

        IEnumerable<BoardGame> GetAvailableTableBoardGameListById(int id);

        IEnumerable<BoardGameObj> GetAvailableTableBoardGameObjsById(int id, Gamer gamer);

        void CreateGameTable(GameTable gameTable, IEnumerable<int> tableBoardGameIdList);

        void EditGameTable(int id, List<int> tableBoardGameIdList);

        void EditGameTableParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer);

        void DeactivateGameTable(int id);
    }
}