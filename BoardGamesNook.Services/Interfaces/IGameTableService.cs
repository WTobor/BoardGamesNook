using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameTableService
    {
        GameTable Get(int id);

        IEnumerable<GameTable> GetAllByGamerNick(string nick);

        IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table);

        void Add(GameTable gameTable);

        void Edit(GameTable gameTable);

        void EditParticipations(List<GameParticipation> gameParticipations);

        void Delete(int id);
    }
}