using System;
using BoardGamesNook.Model;

namespace BoardGameGeekIntegration
{
    public static class BGGBoardGame
    {
        public static BoardGame GetBoardGameId(string name)
        {
            string url = String.Format(Constants.getBoardGameObject, name);
            string BGGBoardGameObject = Request.GetAsync(url).GetAwaiter().GetResult();
            BoardGame boardGame = Properties.GetBoardGameProperties(BGGBoardGameObject);

            return boardGame;
        }
    }
}
