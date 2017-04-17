using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;
using BoardGamesNook.Model;

namespace BoardGameGeekIntegration
{
    public static class BGGBoardGame
    {
        public static int GetBoardGameId(string name)
        {
            int objectId = 0;

            string url = String.Format(Constants.getBoardGameObjectByName, name);
            string BGGBoardGameObjectStr = GetStringResponse(url);
            object boardGamesObject = new Models.boardgames();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.boardgames));
            using (TextReader textReader = new StringReader(BGGBoardGameObjectStr))
            {
                boardGamesObject = xmlSerializer.Deserialize(textReader);
            }

            var boardGames = (Models.boardgames)boardGamesObject;

            if (boardGames.boardgame.Length > 0)
            {
                objectId = (int)boardGames.boardgame.First().objectid;
            }

            return objectId;
        }

        public static BoardGame GetBoardGameById(int id)
        {
            BoardGame boardGame = null;

            string url = String.Format(Constants.getBoardGameObjectDetailsById, id);
            string BGGBoardGameObjectDetailsStr = GetStringResponse(url);
            object boardGamesObjectDetails = new boardgames();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(boardgames));
            using (TextReader textReader = new StringReader(BGGBoardGameObjectDetailsStr))
            {
                boardGamesObjectDetails = xmlSerializer.Deserialize(textReader);
            }

            var boardGameDetails = (boardgames)boardGamesObjectDetails;

            if (boardGameDetails.boardgame != null)
            {
                boardGame = new BoardGame()
                {
                    Name = "",
                    Description = "",
                    MinPlayers = Convert.ToInt32(boardGameDetails.boardgame.Items[1].ToString()),
                    MaxPlayers = Convert.ToInt32(boardGameDetails.boardgame.Items[2].ToString()),
                    MinTime = Convert.ToInt32(boardGameDetails.boardgame.Items[4].ToString()),
                    MaxTime = Convert.ToInt32(boardGameDetails.boardgame.Items[5].ToString()),
                    MinAge = Convert.ToInt32(boardGameDetails.boardgame.Items[6].ToString()),
                    BGGId = id
                };
            }

            return boardGame;
        }

        public static string GetStringResponse(string url)
        {
            string result = string.Empty;
            WebRequest request = WebRequest.Create(url);
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
            return result;
        }
    }
}
