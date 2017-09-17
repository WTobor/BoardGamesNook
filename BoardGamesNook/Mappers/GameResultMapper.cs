using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GameResult;

namespace BoardGamesNook.Mappers
{
    public class GameResultMapper
    {
        public static IEnumerable<GameResultViewModel> MapToGameResultViewModelList(IEnumerable<GameResult> gameResultList, Gamer gamer)
        {
            return gameResultList.Select(x => MapToGameResultViewModel(x, gamer)).ToList();
        }

        public static GameResultViewModel MapToGameResultViewModel(GameResult gameResult, Gamer gamer)
        {
            return new GameResultViewModel()
            {
                CreatedGamerId = gamer.Id,
                CreatedGamerNick = gamer.Nick,
                BoardGameId = gameResult.Id,
                GamerId = gameResult.GamerId,
                BoardGameName = gameResult.BoardGame == null ? "" : gameResult.BoardGame.Name,
                GamerNick = gameResult.Gamer == null ? "" : gameResult.Gamer.Nick,
                Points = gameResult.Points,
                PlayersNumber = gameResult.PlayersNumber,
                Place = gameResult.Place
            };
        }
    }
}