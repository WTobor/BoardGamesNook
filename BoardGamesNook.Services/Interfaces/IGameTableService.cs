using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameTableService
    {
        GameTable Get(int id);

        IEnumerable<GameTable> GetAll();

        void Add(GameTable gameTable);

        void Edit(GameTable gameTable);

        void Delete(int id);
    }
}
