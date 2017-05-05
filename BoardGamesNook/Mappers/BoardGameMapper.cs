using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.Mappers
{
    public class BoardGameMapper
    {
        public static IEnumerable<GamerBoardGameViewModel> MapToGamerBoardGameViewModelList(IEnumerable<BoardGame> boardGameList, Gamer gamer)
        {
            return boardGameList.Select(x => MapToGamerBoardGameViewModel(x, gamer)).ToList();
        }

        public static GamerBoardGameViewModel MapToGamerBoardGameViewModel(BoardGame boardGame, Gamer gamer)
        {
            return new GamerBoardGameViewModel()
            {
                BoardGameId = boardGame.Id,
                GamerId = gamer.Id,
                BGGId = boardGame.BGGId,
                BoardGameName = boardGame.Name,
                GamerNick = gamer.Nick,
                ImageUrl = boardGame.ImageUrl
            };
        }
    }
}