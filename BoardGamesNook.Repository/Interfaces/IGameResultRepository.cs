using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameResultRepository
    {
        GameResult GetGameResult(int id);

        IEnumerable<GameResult> GetAllGameResults();

        IEnumerable<GameResult> GetAllGameResultsByTableId(int id);

        IEnumerable<GameResult> GetAllGameResultsByGamerNickname(string nickname);

        void AddGameResult(GameResult gameResult);

        void AddGameResults(List<GameResult> gameResults);

        void EditGameResult(GameResult gameResult);

        void DeleteGameResult(int id);
    }
}