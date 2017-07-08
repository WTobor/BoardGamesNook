using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.Mappers
{
    public static class GamerBoardGameMapper
    {
        public static IEnumerable<GamerBoardGameViewModel> MapToGamerBoardGameViewModelList(IEnumerable<GamerBoardGame> gamerBoardGameList)
        {
            return gamerBoardGameList.Select(x => MapToGamerBoardGameViewModel(x)).ToList();
        }

        public static GamerBoardGameViewModel MapToGamerBoardGameViewModel(GamerBoardGame gamerBoardGame)
        {
            return new GamerBoardGameViewModel()
            {
                Id = gamerBoardGame.Id,
                BoardGameId = gamerBoardGame.BoardGameId,
                GamerId = gamerBoardGame.GamerId,
                BGGId = gamerBoardGame.BoardGame.BGGId,
                BoardGameName = gamerBoardGame.BoardGame.Name,
                GamerNick = gamerBoardGame.Gamer.Nick,
                ImageUrl = gamerBoardGame.BoardGame.ImageUrl
            };
        }
    }
}