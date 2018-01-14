using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameResultRepository
    {
        GameResult GetGameResult(int id);

        IEnumerable<GameResult> GetAllGameResults();

        IEnumerable<GameResult> GetAllGameResultsByTableId(int id);

        IEnumerable<GameResult> GetAllGameResultsByGamerNick(string nick);

        void AddGameResult(GameResult gameResult);

        void EditGameResult(GameResult gameResult);

        void DeleteGameResult(int id);
    }
}