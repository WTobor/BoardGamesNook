using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameResultService
    {
        GameResult GetGameResult(int id);

        IEnumerable<GameResult> GetAllGameResults();

        IEnumerable<GameResult> GetAllGameResultsByTableId(int id);

        IEnumerable<GameResult> GetAllByGamerNickname(string nickname);

        void AddGameResult(GameResult gameResult);

        void AddGameResults(List<GameResult> gameResults);

        void EditGameResult(GameResult gameResult);

        void DeleteGameResult(int id);
    }
}