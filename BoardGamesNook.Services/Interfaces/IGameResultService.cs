using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameResultService
    {
        GameResult Get(int id);

        IEnumerable<GameResult> GetAll();

        IEnumerable<GameResult> GetAllByTableId(int id);

        IEnumerable<GameResult> GetAllByGamerNick(string nick);

        void Add(GameResult gameResult);

        void Edit(GameResult gameResult);

        void Delete(int id);
    }
}