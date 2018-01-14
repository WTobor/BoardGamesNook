using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameResultService
    {
        GameResult GetGameResult(int id);

        IEnumerable<GameResult> GetAllGameResults();

        IEnumerable<GameResult> GetAllGameResultsByTableId(int id);

        IEnumerable<GameResult> GetAllByGamerNick(string nick);

        void AddGameResult(GameResult gameResult);

        void Edit(GameResult gameResult);

        void DeleteGameResult(int id);
    }
}