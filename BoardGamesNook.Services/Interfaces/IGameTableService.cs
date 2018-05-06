using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Models;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameTableService
    {
        GameTable GetGameTable(int id);

        GameTableDto GetGameTableObj(int id);

        IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname);

        IEnumerable<GameTable> GetAllGameTablesWithoutResultsByGamerNickname(string gamerNickname);

        IEnumerable<GameTableDto> GetAllGameTableObjsWithoutResultsByGamerNickname(string gamerNickname);

        IEnumerable<GameTableDto> GetAllGameTableObjsByGamerNickname(string gamerNickname);

        IEnumerable<GameTable> GetAllGameTables();

        IEnumerable<GameTableDto> GetAllGameTableObjs();

        IEnumerable<BoardGame> GetAvailableTableBoardGameListById(int id);

        IEnumerable<BoardGame> GetAvailableTableBoardGamesById(int id, Gamer gamer);

        void CreateGameTable(GameTable gameTable, IEnumerable<int> tableBoardGameIdList);

        void EditGameTable(int id, List<int> tableBoardGameIdList);

        void EditGameTableParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer);

        void DeactivateGameTable(int id);
    }
}