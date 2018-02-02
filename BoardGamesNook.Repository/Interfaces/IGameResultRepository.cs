using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameResultRepository
    {
        GameResult Get(int id);

        IEnumerable<GameResult> GetAll();

        IEnumerable<GameResult> GetAllByTableId(int id);

        IEnumerable<GameResult> GetAllByGamerNickname(string nickname);

        void Add(GameResult gameResult);

        void AddMany(List<GameResult> gameResults);

        void Edit(GameResult gameResult);

        void Deactivate(int id);
    }
}