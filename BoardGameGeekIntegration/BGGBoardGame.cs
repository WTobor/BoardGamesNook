using BoardGamesNook.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;

namespace BoardGameGeekIntegration
{
    public static class BGGBoardGame
    {
        public static int GetBoardGameId(string name)
        {
            int objectId = 0;

            string url = String.Format(Constants.getXMLBoardGameObjectByName, name);
            string BGGBoardGameObjectStr = GetStringResponse(url);
            object boardGamesObject = new Models.boardgames();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.boardgames));
            using (TextReader textReader = new StringReader(BGGBoardGameObjectStr))
            {
                boardGamesObject = xmlSerializer.Deserialize(textReader);
            }

            var boardGames = (Models.boardgames)boardGamesObject;

            if (boardGames.boardgame != null && boardGames.boardgame.Length > 0)
            {
                objectId = (int)boardGames.boardgame.First().objectid;
            }

            return objectId;
        }

        public static BoardGame GetBoardGameById(int id)
        {
            BoardGame boardGame = null;

            string url = String.Format(Constants.getJSONBoardGameObjectDetailsById, id);
            string BGGBoardGameObjectDetailsStr = GetStringResponse(url);

            BoardGameDetails boardGameDetails = JsonConvert.DeserializeObject<BoardGameDetails>(BGGBoardGameObjectDetailsStr);

            boardGame = new BoardGame()
            {
                Name = boardGameDetails.name,
                Description = boardGameDetails.description,
                MinPlayers = boardGameDetails.minPlayers,
                MaxPlayers = boardGameDetails.maxPlayers,
                MaxTime = boardGameDetails.playingTime,
                BGGId = id,
                IsExpansion = boardGameDetails.isExpansion,
                ImageUrl = boardGameDetails.thumbnail,
                CreatedDate = DateTimeOffset.Now
            };

            return boardGame;
        }

        public static string GetStringResponse(string url)
        {
            string result = string.Empty;
            WebRequest request = WebRequest.Create(url);
            request.ContentType = "text/javascript";
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
