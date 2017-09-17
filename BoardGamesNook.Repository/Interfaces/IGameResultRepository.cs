using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameResultRepository
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