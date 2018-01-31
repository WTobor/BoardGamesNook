using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameTableRepository
    {
        GameTable Get(int id);

        IEnumerable<GameTable> GetAllGameTables();

        IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table);

        IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname);

        void AddGameTable(GameTable gameTable);

        void EditGameTableParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer);

        void EditGameTable(GameTable gameTable);

        void Deactivate(int id);
    }
}