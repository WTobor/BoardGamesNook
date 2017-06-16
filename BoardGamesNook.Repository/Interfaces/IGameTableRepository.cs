using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameTableRepository
    {
        GameTable Get(int id);

        IEnumerable<GameTable> GetAll();

        IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table);

        IEnumerable<GameTable> GetAllByGamerId(string id);

        void Add(GameTable gameTable);

        void Edit(GameTable gameTable);

        void Delete(int id);
    }
}