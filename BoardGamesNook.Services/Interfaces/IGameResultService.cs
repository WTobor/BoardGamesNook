using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Models;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameResultService
    {
        GameResultDto GetGameResult(int id);

        IEnumerable<GameResultDto> GetAllGameResults();

        IEnumerable<GameResult> GetAllGameResultsByTableId(int id);

        IEnumerable<GameResultDto> GetAllByGamerNickname(string nickname);

        void AddGameResult(GameResult gameResult);

        void AddGameResults(List<GameResult> gameResults);

        void EditGameResult(GameResult gameResult);

        void DeactivateGameResult(int id);
    }
}